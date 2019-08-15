using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using Rental.Common;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.Core.Models.Validation;
using Rental.Core.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class AddGameRentalCommandHandler : ICommandHandler<AddGameRentalCommand>
    {
        private readonly IMediatorService _mediatorService;

        public AddGameRentalCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task Handle(AddGameRentalCommand command, CancellationToken cancellationToken)
        {
            var validator = new RentalValidation();
            var newGameRental = new GameRental(command.NewGameRentalGuid, command.ClientGuid, command.BoardGameGuid,
                command.ChargedDeposit);
            var validationResult = validator.Validate(newGameRental);
            if (validationResult.IsValid)
            {
                var gameCanBeRented =
                    await _mediatorService.Send(
                        new CheckIfBoardGameHasOnlyCompletedRentalsQuery(command.BoardGameGuid),
                        cancellationToken);
                if (gameCanBeRented)
                    await _mediatorService.Send(new AddAndSaveRentalCommand(newGameRental), cancellationToken);
                else
                    validationResult.Errors.Add(new ValidationFailure(nameof(newGameRental.BoardGameId),
                        $"BoardGame {command.BoardGameGuid} is not available for rental - already rented"));
            }
            else
            {
                var validationMessage =
                    await _mediatorService.Send(new GetFormattedValidationMessageQuery(validationResult.Errors),
                        cancellationToken);
                throw new ValidationException(validationMessage);
            }
        }
    }
}