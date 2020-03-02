using System.Collections.Generic;
using Playingo.Domain.BoardGames;
using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Queries
{
    public class GetAllBoardGamesQuery : IQuery<IList<BoardGame>>
    {
    }
}