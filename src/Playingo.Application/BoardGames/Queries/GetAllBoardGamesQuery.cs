using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.BoardGames;

namespace Playingo.Application.BoardGames.Queries
{
    public class GetAllBoardGamesQuery : IQuery<IList<BoardGame>>
    {
    }

    internal class GetAllBoardGamesQueryHandler : IQueryHandler<GetAllBoardGamesQuery, IList<BoardGame>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBoardGamesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<BoardGame>> Handle(GetAllBoardGamesQuery query, CancellationToken cancellationToken)
        {
            var boardGames = await _unitOfWork.BoardGameRepository.GetAllAsync(cancellationToken);
            return boardGames;
        }
    }
}