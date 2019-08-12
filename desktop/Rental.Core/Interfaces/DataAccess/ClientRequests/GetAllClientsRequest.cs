using System.Collections.Generic;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.ClientRequests
{
    public class GetAllClientsRequest : IRequest<IList<Client>>
    {
    }
}