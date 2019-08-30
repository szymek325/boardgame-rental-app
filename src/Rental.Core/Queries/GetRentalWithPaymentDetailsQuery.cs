using System;
using Rental.Core.Models.Rentals;
using Rental.CQS;

namespace Rental.Core.Queries
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