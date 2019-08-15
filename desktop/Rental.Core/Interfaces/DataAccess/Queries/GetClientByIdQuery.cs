using System;
using MediatR;
using Rental.Common;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.Queries
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