using System;
using System.Collections.Generic;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetAllRentalsForClientQuery : IQuery<IList<Models.Rentals.Rental>>
    {
        public GetAllRentalsForClientQuery(Guid clientId)
        {
            ClientId = clientId;
        }

        public Guid ClientId { get; set; }
    }
}