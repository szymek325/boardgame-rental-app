using System;

namespace Rental.Core.Models.Rentals
{
    internal class RentalDay
    {
        public DateTime Day { get; set; }
        public string DayName { get; set; }
        public float AmountDue { get; set; }
    }
}