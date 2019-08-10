using System.Collections.Generic;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.BoardGameRequests
{
    public class GetAllGameBoardsRequest : IRequest, IRequest<IList<Models.Client>>
    {
    }
}