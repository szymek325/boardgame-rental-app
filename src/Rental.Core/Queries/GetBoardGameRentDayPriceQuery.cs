using Rental.CQS;

namespace Rental.Core.Queries
{
    internal class GetBoardGameRentDayPriceQuery : IQuery<float>
    {
        public GetBoardGameRentDayPriceQuery(float boardGamePrice)
        {
            BoardGamePrice = boardGamePrice;
        }

        public float BoardGamePrice { get; set; }
    }
}