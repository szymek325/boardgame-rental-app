using System.Collections.Generic;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Requests
{
    public class GetAllClientsRequest : IRequest, IRequest<IList<Client>>
    {
    }
}