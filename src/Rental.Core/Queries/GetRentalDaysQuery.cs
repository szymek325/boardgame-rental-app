using System;
using System.Collections.Generic;
using Rental.Core.Models.Rentals;
using Rental.CQRS;

namespace Rental.Core.Queries
{
    internal class GetRentalDaysQuery : IQuery<IList<RentalDay>>
    {
        public GetRentalDaysQuery(float boardGamePrice, DateTime rentStartDate)
        {
            BoardGamePrice = boardGamePrice;
            RentStartDate = rentStartDate;
        }

        public GetRentalDaysQuery(float boardGamePrice, DateTime rentStartDate, DateTime? rentFinishDate)
        {
            BoardGamePrice = boardGamePrice;
            RentStartDate = rentStartDate;
            RentFinishDate = rentFinishDate;
        }

        public float BoardGamePrice { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime? RentFinishDate { get; set; }
    }
}