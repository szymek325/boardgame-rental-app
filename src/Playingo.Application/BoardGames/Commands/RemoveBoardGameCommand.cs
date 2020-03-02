using System;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Interfaces.DataAccess.Queries;

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
        private readonly IMediatorService _mediatorService;

        public RemoveBoardGameCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task Handle(RemoveBoardGameCommand command, CancellationToken cancellationToken)
        {
            var boardGame = await _mediatorService.Send(new GetBoardGameByIdQuery(command.Id), cancellationToken);
            if (boardGame == null)
                throw new BoardGameNotFoundException(command.Id);

            var hasOnlyCompletedRentals =
                await _mediatorService.Send(new CheckIfBoardGameHasOnlyCompletedRentalsQuery(command.Id),
                    cancellationToken);
            if (!hasOnlyCompletedRentals)
                throw new BoardGameHasOpenRentalException(command.Id);

            await _mediatorService.Send(new RemoveAndSaveBoardGameByIdCommand(command.Id), cancellationToken);
        }
    }
}