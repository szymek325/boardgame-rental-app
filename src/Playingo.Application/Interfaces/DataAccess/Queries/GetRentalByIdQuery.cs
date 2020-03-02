using System;
using Playingo.Application.Common.Mediator;

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