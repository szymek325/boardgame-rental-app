using System.Collections.Generic;
using Playingo.Domain.Clients;
using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Queries
{
    public class GetAllClientsQuery : IQuery<IList<Client>>
    {
    }
}