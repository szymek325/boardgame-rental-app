using System.Collections.Generic;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.ClientRequests
{
    public class GetAllClientsRequest : IRequest, IRequest<IList<Models.Client>>
    {
    }
}