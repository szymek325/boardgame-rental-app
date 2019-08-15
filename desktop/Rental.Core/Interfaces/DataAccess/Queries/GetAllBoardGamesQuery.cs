using System.Collections.Generic;
using MediatR;
using Rental.Common;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetAllBoardGamesQuery : IQuery<IList<BoardGame>>
    {
    }
}