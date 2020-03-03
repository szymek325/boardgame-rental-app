using System;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Clients.Queries;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.Clients.Commands
{
    public class RemoveClientCommand : ICommand
    {
        public RemoveClientCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    internal class RemoveClientCommandHandler : ICommandHandler<RemoveClientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientRepository.GetByIdAsync( command.Id, cancellationToken);
            if (client == null)
                throw new ClientNotFoundException(command.Id);

            var hasOnlyCompletedRentals =
                await _unitOfWork.RentalRepository.AreAllCompletedForClientAsync(command.Id, cancellationToken);
            if (!hasOnlyCompletedRentals)
                throw new ClientHasOpenRentalException(command.Id);

            await _unitOfWork.ClientRepository.RemoveByIdAsync(command.Id,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}