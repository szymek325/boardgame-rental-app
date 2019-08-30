using System.Threading;
using System.Threading.Tasks;
using Rental.CQRS;

namespace Rental.Core.Queries.Handlers
{
    internal class GetBoardGameRentDayPriceQueryHandler : IQueryHandler<GetBoardGameRentDayPriceQuery, decimal>
    {
        //TODO get percent value from config
        public Task<decimal> Handle(GetBoardGameRentDayPriceQuery request, CancellationToken cancellationToken)
        {
            var percentValue = (decimal) 7 / 10;
            var dailyPrice = percentValue * request.BoardGamePrice;
            return Task.FromResult(dailyPrice);
        }
    }
}