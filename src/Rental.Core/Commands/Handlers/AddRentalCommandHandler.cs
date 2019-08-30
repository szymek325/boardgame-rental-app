using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Rental.Core.Common.Exceptions;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.Core.Queries;
using Rental.CQS;

namespace Rental.Core.Commands.Handlers
{
    internal class AddRentalCommandHandler : ICommandHandler<AddRentalCommand>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IValidator<Models.Rentals.Rental> _validator;

        public AddRentalCommandHandler(IMediatorService mediatorService, IValidator<Models.Rentals.Rental> validator)
        {
            _mediatorService = mediatorService;
            _validator = validator;
        }

        public async Task Handle(AddRentalCommand command, CancellationToken cancellationToken)
        {
            var newGameRental = new Models.Rentals.Rental(command.NewGameRentalGuid, command.ClientGuid, command.BoardGameGuid,
                command.ChargedDeposit)
            {
                Status = Status.InProgress
            };
            var validationResult = _validator.Validate(newGameRental);

            if (!validationResult.IsValid)
            {
                var validationMessage =
                    await _mediatorService.Send(new GetFormattedValidationMessageQuery(validationResult.Errors),
                        cancellationToken);
                throw new CustomValidationException(validationMessage);
            }

            var client = _mediatorService.Send(new GetClientByIdQuery(command.ClientGuid), cancellationToken);
            var boardGame = _mediatorService.Send(new GetBoardGameByIdQuery(command.BoardGameGuid), cancellationToken);
            var canBeRented = _mediatorService.Send(new CheckIfBoardGameHasOnlyCompletedRentalsQuery(command.BoardGameGuid),
                cancellationToken);
            await Task.WhenAll(client, boardGame, canBeRented);

            if (client.Result == null)
                throw new ClientNotFoundException(command.ClientGuid);
            if (boardGame.Result == null)
                throw new BoardGameNotFoundException(command.BoardGameGuid);
            if (!canBeRented.Result)
                throw new BoardGameHasOpenRentalException(command.BoardGameGuid);

            await _mediatorService.Send(new AddAndSaveRentalCommand(newGameRental), cancellationToken);
        }
    }
}