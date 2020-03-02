using System.Collections.Generic;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.BoardGames;

namespace Playingo.Application.BoardGames.Queries
{
    public class GetAllBoardGamesQuery : IQuery<IList<BoardGame>>
    {
    }
}