using System;
using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Queries
{
    public class GetRentalByIdQuery : IQuery<Domain.Rentals.Rental>
    {
        public GetRentalByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}