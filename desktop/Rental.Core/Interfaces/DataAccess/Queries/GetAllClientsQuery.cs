using System.Collections.Generic;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetAllClientsQuery : IRequest<IList<Client>>
    {
    }
}