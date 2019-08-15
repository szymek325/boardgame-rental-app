using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using Rental.Core.Common;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.Core.Models.Validation;
using Rental.Core.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class AddGameRentalCommandHandler : AsyncRequestHandler<AddGameRentalCommand>
    {
        private readonly IMediatorService _mediatorService;

        public AddGameRentalCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(AddGameRentalCommand command, CancellationToken cancellationToken)
        {
            var validator = new RentalValidation();
            var newGameRental = new GameRental(command.NewGameRentalGuid, command.ClientGuid, command.BoardGameGuid,
                command.ChargedDeposit);
            var validationResult = validator.Validate(newGameRental);
            if (validationResult.IsValid)
            {
                var gameCanBeRented =
                    await _mediatorService.SendQuery(
                        new CheckIfBoardGameHasOnlyCompletedRentalsQuery(command.BoardGameGuid),
                        cancellationToken);
                if (gameCanBeRented)
                    await _mediatorService.SendCommand(new AddAndSaveRentalCommand(newGameRental), cancellationToken);
                else
                    validationResult.Errors.Add(new ValidationFailure(nameof(newGameRental.BoardGameId),
                        $"BoardGame {command.BoardGameGuid} is not available for rental - already rented"));
            }

            var validationMessage =
                await _mediatorService.SendQuery(new GetFormattedValidationMessageQuery(validationResult.Errors),
                    cancellationToken);
            throw new ValidationException(validationMessage);
        }
    }
}