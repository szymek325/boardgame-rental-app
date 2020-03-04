using System;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Domain;
using Playingo.Domain.Rentals.Exceptions;

namespace Playingo.Application.Rentals.Commands
{
    public class CompleteRentalCommand : ICommand
    {
        public CompleteRentalCommand(Guid gameRentalId, decimal paidMoney)
        {
            GameRentalId = gameRentalId;
            PaidMoney = paidMoney;
        }

        public Guid GameRentalId { get; }
        public decimal PaidMoney { get; }
    }

    internal class CompleteRentalCommandHandler : ICommandHandler<CompleteRentalCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompleteRentalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CompleteRentalCommand command, CancellationToken cancellationToken)
        {
            var rental = await _unitOfWork.RentalRepository.GetByIdAsync(command.GameRentalId, cancellationToken);
            if (rental == null)
                throw new RentalNotFoundException(command.GameRentalId);
            if (rental.Status != Status.InProgress)
                throw new RentalIsNotInProgressException(command.GameRentalId);

            rental.Status = Status.Completed;
            rental.PaidMoney = command.PaidMoney;

            await _unitOfWork.RentalRepository.Update(rental);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}