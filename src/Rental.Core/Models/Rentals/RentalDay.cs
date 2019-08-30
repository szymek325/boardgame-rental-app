using System;

namespace Rental.Core.Models.Rentals
{
    public class RentalDay
    {
        public RentalDay(decimal amountDue, DateTime day)
        {
            AmountDue = amountDue;
            Day = day;
        }

        public decimal AmountDue { get; set; }
        public DateTime Day { get; set; }
        public string DayName => Day.DayOfWeek.ToString();
    }
}