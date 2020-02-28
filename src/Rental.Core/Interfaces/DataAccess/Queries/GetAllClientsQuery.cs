using System.Collections.Generic;
using Playingo.Domain.Clients;
using Rental.CQS;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetAllClientsQuery : IQuery<IList<Client>>
    {
    }
}