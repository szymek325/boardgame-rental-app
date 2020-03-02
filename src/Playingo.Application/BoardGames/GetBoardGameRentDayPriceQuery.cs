using Playingo.Application.Common.Mediator;

namespace Playingo.Application.BoardGames
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