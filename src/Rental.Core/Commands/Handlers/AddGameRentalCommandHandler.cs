using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Rental.Core.Common.Exceptions;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.Core.Queries;
using Rental.CQRS;

namespace Rental.Core.Commands.Handlers
{
    internal class AddGameRentalCommandHandler : ICommandHandler<AddGameRentalCommand>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IValidator<GameRental> _validator;

        public AddGameRentalCommandHandler(IMediatorService mediatorService, IValidator<GameRental> validator)
        {
            _mediatorService = mediatorService;
            _validator = validator;
        }

        public async Task Handle(AddGameRentalCommand command, CancellationToken cancellationToken)
        {
            var newGameRental = new GameRental(command.NewGameRentalGuid, command.ClientGuid, command.BoardGameGuid,
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

            var client = await _mediatorService.Send(new GetClientByIdQuery(command.ClientGuid), cancellationToken);
            if (client == null)
                throw new ClientNotFoundException(command.ClientGuid);

            var boardGame =
                await _mediatorService.Send(new GetBoardGameByIdQuery(command.ClientGuid), cancellationToken);
            if (boardGame == null)
                throw new BoardGameNotFoundException(command.BoardGameGuid);

            var canBeRented =
                await _mediatorService.Send(
                    new CheckIfBoardGameHasOnlyCompletedRentalsQuery(command.BoardGameGuid),
                    cancellationToken);
            if (!canBeRented)
                throw new BoardGameHasOpenRentalException(command.BoardGameGuid);

            await _mediatorService.Send(new AddAndSaveRentalCommand(newGameRental), cancellationToken);
        }
    }
}