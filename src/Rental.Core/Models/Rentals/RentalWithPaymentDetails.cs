using System;
using System.Collections.Generic;

namespace Rental.Core.Models.Rentals
{
    public class RentalWithPaymentDetails
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string BoardGameName { get; set; }
        public float ChargedDeposit { get; set; }
        public DateTime RentalStartDateTime { get; set; }
        public float MoneyToPay { get; set; }
        public ICollection<RentalDay> RentalDays { get; set; }
    }
}