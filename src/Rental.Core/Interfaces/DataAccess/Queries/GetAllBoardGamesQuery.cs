using System.Collections.Generic;
using Rental.Core.Models.BoardGames;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetAllBoardGamesQuery : IQuery<IList<BoardGame>>
    {
    }
}