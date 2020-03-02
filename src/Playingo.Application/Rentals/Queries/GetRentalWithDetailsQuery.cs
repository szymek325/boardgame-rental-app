using System;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Rentals.Queries
{
    public class GetRentalWithDetailsQuery : IQuery<RentalWithDetails>
    {
        public GetRentalWithDetailsQuery(Guid gameRentalGuid)
        {
            GameRentalGuid = gameRentalGuid;
        }

        public Guid GameRentalGuid { get; set; }
    }
}