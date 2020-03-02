using System;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.Interfaces.DataAccess.Queries
{
    public class CheckIfClientHasOnlyCompletedRentalsQuery : IQuery<bool>
    {
        public CheckIfClientHasOnlyCompletedRentalsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}