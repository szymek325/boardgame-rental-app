using Rental.CQRS;

namespace Rental.Core.Queries
{
    internal class GetBoardGameRentDayPriceQuery : IQuery<decimal>
    {
        public GetBoardGameRentDayPriceQuery(decimal boardGamePrice)
        {
            BoardGamePrice = boardGamePrice;
        }

        public decimal BoardGamePrice { get; set; }
    }
}