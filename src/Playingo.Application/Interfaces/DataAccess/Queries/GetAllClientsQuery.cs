using System.Collections.Generic;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Clients;

namespace Playingo.Application.Interfaces.DataAccess.Queries
{
    public class GetAllClientsQuery : IQuery<IList<Client>>
    {
    }
}