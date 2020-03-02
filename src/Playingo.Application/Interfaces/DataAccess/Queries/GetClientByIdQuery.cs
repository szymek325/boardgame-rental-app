using System;
using Playingo.Domain.Clients;
using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Queries
{
    public class GetClientByIdQuery : IQuery<Client>
    {
        public GetClientByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}