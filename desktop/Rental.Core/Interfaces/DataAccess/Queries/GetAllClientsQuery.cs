using System.Collections.Generic;
using Rental.Core.Models;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetAllClientsQuery : IQuery<IList<Client>>
    {
    }
}