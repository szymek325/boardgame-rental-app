using System.Threading;
using System.Threading.Tasks;
using Rental.CQRS;

namespace Rental.Core.Queries.Handlers
{
    internal class GetBoardGameRentDayPriceQueryHandler : IQueryHandler<GetBoardGameRentDayPriceQuery, float>
    {
        //TODO get percent vlaue from config
        public Task<float> Handle(GetBoardGameRentDayPriceQuery request, CancellationToken cancellationToken)
        {
            var dailyPrice =(float) 7 / 100 * request.BoardGamePrice;
            return Task.FromResult(dailyPrice);
        }
    }
}