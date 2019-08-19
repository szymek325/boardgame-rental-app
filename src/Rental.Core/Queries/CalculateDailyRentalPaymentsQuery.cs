using System;
using System.Collections.Generic;
using Rental.Core.Models.Rentals;
using Rental.CQRS;

namespace Rental.Core.Queries
{
    internal class CalculateDailyRentalPaymentsQuery : IQuery<IList<RentalDay>>
    {
        public CalculateDailyRentalPaymentsQuery(float boardGamePrice, DateTime rentStartDate)
        {
            BoardGamePrice = boardGamePrice;
            RentStartDate = rentStartDate;
        }

        public float BoardGamePrice { get; set; }
        public DateTime RentStartDate { get; set; }
    }
}