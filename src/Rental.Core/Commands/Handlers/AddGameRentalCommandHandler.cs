﻿using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
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
                command.ChargedDeposit);
            var validationResult = _validator.Validate(newGameRental);
            if (validationResult.IsValid)
            {
                var gameCanBeRented =
                    await _mediatorService.Send(
                        new CheckIfBoardGameCanBeRemovedQuery(command.BoardGameGuid),
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
                throw new CustomValidationException(validationMessage);
            }
        }
    }
}