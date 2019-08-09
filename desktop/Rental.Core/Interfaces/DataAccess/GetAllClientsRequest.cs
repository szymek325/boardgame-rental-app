using System.Collections.Generic;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess
{
    public class GetAllClientsRequest : IRequest, IRequest<IList<Client>>
    {
    }
}