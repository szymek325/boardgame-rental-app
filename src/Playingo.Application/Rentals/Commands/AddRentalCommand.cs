using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Playingo.Application.BoardGames.Queries;
using Playingo.Application.Clients.Queries;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Validation;
using Playingo.Domain;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Rentals.Commands
{
    public class AddRentalCommand : ICommand
    {
        public AddRentalCommand(Guid newGameRentalGuid, Guid clientGuid, Guid boardGameGuid, decimal chargedDeposit)
        {
            NewGameRentalGuid = newGameRentalGuid;
            ClientGuid = clientGuid;
            BoardGameGuid = boardGameGuid;
            ChargedDeposit = chargedDeposit;
        }

        public Guid NewGameRentalGuid { get; set; }
        public Guid ClientGuid { get; }
        public Guid BoardGameGuid { get; }
        public decimal ChargedDeposit { get; }
    }

    internal class AddRentalCommandHandler : ICommandHandler<AddRentalCommand>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IValidator<Rental> _validator;

        public AddRentalCommandHandler(IMediatorService mediatorService, IValidator<Rental> validator)
        {
            _mediatorService = mediatorService;
            _validator = validator;
        }

        public async Task Handle(AddRentalCommand command, CancellationToken cancellationToken)
        {
            var newGameRental = new Rental(command.NewGameRentalGuid, command.ClientGuid,
                command.BoardGameGuid,
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
            var canBeRented = _mediatorService.Send(
                new CheckIfBoardGameHasOnlyCompletedRentalsQuery(command.BoardGameGuid),
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