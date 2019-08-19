using System;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetRentalByIdQuery : IQuery<Models.Rental>
    {
        public GetRentalByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}