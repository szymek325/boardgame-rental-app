using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Rental.Core.Queries;
using Rental.Core.Queries.Handlers;
using Rental.CQRS;
using Xunit;

namespace Rental.Core.Tests.Queries
{
    public class GetBoardGameRentDayPriceQueryHandlerTests
    {
        public GetBoardGameRentDayPriceQueryHandlerTests()
        {
            _sut = new GetBoardGameRentDayPriceQueryHandler();
        }

        private readonly IQueryHandler<GetBoardGameRentDayPriceQuery, decimal> _sut;
        private readonly CancellationToken _cancellationToken = new CancellationToken();

        [Fact]
        public async Task Handle_Should_Return_7_When_100()
        {
            var input = 100;

            var result = await _sut.Handle(new GetBoardGameRentDayPriceQuery(input), _cancellationToken);

            result.Should().Be(7);
        }
    }
}