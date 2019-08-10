using System.Collections.Generic;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.BoardGameRequests
{
    public class GetAllBoardGamesRequest : IRequest, IRequest<IList<BoardGame>>
    {
    }
}