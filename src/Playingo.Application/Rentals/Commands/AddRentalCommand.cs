using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationMessageBuilder _validationMessageBuilder;
        private readonly IValidator<Rental> _validator;

        public AddRentalCommandHandler(IUnitOfWork unitOfWork, IValidationMessageBuilder validationMessageBuilder,
            IValidator<Rental> validator)
        {
            _unitOfWork = unitOfWork;
            _validationMessageBuilder = validationMessageBuilder;
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
                var validationMessage = _validationMessageBuilder.CreateMessage(validationResult.Errors);
                throw new CustomValidationException(validationMessage);
            }

            var client = _unitOfWork.ClientRepository.GetByIdAsync(command.ClientGuid, cancellationToken);
            var boardGame = _unitOfWork.BoardGameRepository.GetByIdAsync(command.BoardGameGuid, cancellationToken);
            var canBeRented =
                _unitOfWork.RentalRepository.AreAllCompletedForBoardGameAsync(command.BoardGameGuid, cancellationToken);
            await Task.WhenAll(client, boardGame, canBeRented);

            if (client.Result == null)
                throw new ClientNotFoundException(command.ClientGuid);
            if (boardGame.Result == null)
                throw new BoardGameNotFoundException(command.BoardGameGuid);
            if (!canBeRented.Result)
                throw new BoardGameHasOpenRentalException(command.BoardGameGuid);

            await _unitOfWork.RentalRepository.AddAsync(newGameRental, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}