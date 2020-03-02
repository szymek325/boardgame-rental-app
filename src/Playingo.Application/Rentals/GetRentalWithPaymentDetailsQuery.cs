using System;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Rentals
{
    public class GetRentalWithPaymentDetailsQuery : IQuery<RentalWithPaymentDetails>
    {
        public GetRentalWithPaymentDetailsQuery(Guid rentalGuid)
        {
            RentalGuid = rentalGuid;
        }

        public Guid RentalGuid { get; set; }
    }
}