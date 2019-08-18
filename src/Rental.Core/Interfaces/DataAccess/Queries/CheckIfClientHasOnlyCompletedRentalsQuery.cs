using System;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Queries
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