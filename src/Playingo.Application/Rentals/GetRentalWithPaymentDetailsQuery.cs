using System;
using Playingo.Domain.Rentals;
using Rental.CQS;

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