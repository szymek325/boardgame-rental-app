using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Rental.Core.Common.Configuration;
using Rental.Core.Queries;
using Rental.Core.Queries.Handlers;
using Rental.CQS;
using Xunit;

namespace Rental.Core.Tests.Queries
{
    public class GetBoardGameRentDayPriceQueryHandlerTests
    {
        public GetBoardGameRentDayPriceQueryHandlerTests()
        {
            _pricesOptions = Options.Create(new PricesConfiguration
            {
                DailyRentPercent = 7,
                DepositPercent = 50
            });
            _sut = new GetBoardGameRentDayPriceQueryHandler(_pricesOptions);
        }

        private readonly IOptions<PricesConfiguration> _pricesOptions;
        private readonly IQueryHandler<GetBoardGameRentDayPriceQuery, decimal> _sut;
        private readonly CancellationToken _cancellationToken = new CancellationToken();

        [Fact]
        public async Task Handle_Should_Return_7PercentOfInputOfPrice()
        {
            var input = 100;

            var result = await _sut.Handle(new GetBoardGameRentDayPriceQuery(input), _cancellationToken);

            result.Should().Be(7);
        }
    }
}