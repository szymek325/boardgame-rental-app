using System;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.BoardGames.Commands
{
    public class RemoveBoardGameCommand : ICommand
    {
        public RemoveBoardGameCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    internal class RemoveBoardGameCommandHandler : ICommandHandler<RemoveBoardGameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveBoardGameCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveBoardGameCommand command, CancellationToken cancellationToken)
        {
            var boardGame = await _unitOfWork.BoardGameRepository.GetByIdAsync(command.Id, cancellationToken);
            if (boardGame == null)
                throw new BoardGameNotFoundException(command.Id);

            var hasOnlyCompletedRentals =
                await _unitOfWork.RentalRepository.AreAllCompletedForBoardGameAsync(command.Id, cancellationToken);
            if (!hasOnlyCompletedRentals)
                throw new BoardGameHasOpenRentalException(command.Id);

            await _unitOfWork.BoardGameRepository.RemoveByIdAsync(command.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}