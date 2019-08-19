using System;

namespace Rental.Core.Models.Rentals
{
    public class RentalDay
    {
        public RentalDay(float amountDue, DateTime day)
        {
            AmountDue = amountDue;
            Day = day;
        }

        public float AmountDue { get; set; }
        public DateTime Day { get; set; }
        public string DayName => Day.DayOfWeek.ToString();
    }
}