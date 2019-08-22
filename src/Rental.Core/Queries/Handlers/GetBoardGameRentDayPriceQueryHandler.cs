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
            return Task.FromResult(7 / 100 * request.BoardGamePrice);
        }
    }
}