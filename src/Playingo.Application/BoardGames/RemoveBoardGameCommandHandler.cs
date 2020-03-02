using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Rental.CQS;

namespace Playingo.Application.BoardGames
{
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