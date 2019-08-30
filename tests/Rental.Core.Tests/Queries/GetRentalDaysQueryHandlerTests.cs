using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rental.Core.Common.Helpers;
using Rental.Core.Models.Rentals;
using Rental.Core.Queries;
using Rental.Core.Queries.Handlers;
using Rental.CQS;
using Xunit;

namespace Rental.Core.Tests.Queries
{
    public class GetRentalDaysQueryHandlerTests
    {
        public GetRentalDaysQueryHandlerTests()
        {
            _dateTimeProvider = new Mock<IDateTimeProvider>(MockBehavior.Strict);
            _dateTimeProvider.Setup(x => x.UtcNow).Returns(_actualTime);
            _mediatorService = new Mock<IMediatorService>();
            _sut = new GetRentalDaysQueryHandler(_dateTimeProvider.Object, _mediatorService.Object);
        }

        private readonly DateTime _actualTime = DateTime.Now;
        private readonly Mock<IDateTimeProvider> _dateTimeProvider;
        private readonly Mock<IMediatorService> _mediatorService;
        private readonly CancellationToken _cancellationToken = new CancellationToken();
        private readonly IQueryHandler<GetRentalDaysQuery, IList<RentalDay>> _sut;
        private const decimal OneDayPrice = (decimal) 10.5;

        public static IEnumerable<object[]> NumberOfDaysRange =>
            Enumerable.Range(1, 10).Select(x => new[] {(object) x}).ToList();

        [Theory]
        [MemberData(nameof(NumberOfDaysRange))]
        public async Task Handle_Should_ReturnRentalDayForEachPassedDayUntilToday_When_FinishDateIsNotPassed(int days)
        {
            var today = _actualTime;
            var startDate = today.AddDays(-days);
            var input = new GetRentalDaysQuery(15, startDate);
            _mediatorService.Setup(x =>
                    x.Send(It.Is<GetBoardGameRentDayPriceQuery>(x => x.BoardGamePrice == input.BoardGamePrice), _cancellationToken))
                .ReturnsAsync(OneDayPrice);

            var result = await _sut.Handle(input, _cancellationToken);

            result.Count.Should().Be(days);
            foreach (var rentalDay in result)
            {
                rentalDay.AmountDue.Should().Be(OneDayPrice);
                rentalDay.DayName.Should().Be(rentalDay.Day.DayOfWeek.ToString());
            }
        }

        [Theory]
        [MemberData(nameof(NumberOfDaysRange))]
        public async Task Handle_Should_ReturnRentalDayForEachPassedDayWithoutFinishDate_When_FinishDayHasExactlyTheSameHourAndMinutes(
            int days)
        {
            var finishDate = _actualTime;
            var startDate = finishDate.AddDays(-days);
            var input = new GetRentalDaysQuery(15, startDate, finishDate);
            _mediatorService.Setup(x =>
                    x.Send(It.Is<GetBoardGameRentDayPriceQuery>(x => x.BoardGamePrice == input.BoardGamePrice), _cancellationToken))
                .ReturnsAsync(OneDayPrice);

            var result = await _sut.Handle(input, _cancellationToken);

            result.Count.Should().Be(days);
            foreach (var rentalDay in result)
            {
                rentalDay.AmountDue.Should().Be(OneDayPrice);
                rentalDay.DayName.Should().Be(rentalDay.Day.DayOfWeek.ToString());
            }

            result.First().Day.Should().Be(startDate.Date);
            result.Last().Day.Should().Be(finishDate.Date.AddDays(-1));
        }

        [Theory]
        [MemberData(nameof(NumberOfDaysRange))]
        public async Task Handle_Should_ReturnRentalDayForEachPassedDayWithFinishDate_When_FinishDayIsBiggerByOneMinuteOrMore(int days)
        {
            var finishDate = _actualTime;
            var startDate = finishDate.AddDays(-days);
            finishDate = finishDate.AddMinutes(+1);
            var input = new GetRentalDaysQuery(15, startDate, finishDate);
            _mediatorService.Setup(x =>
                    x.Send(It.Is<GetBoardGameRentDayPriceQuery>(x => x.BoardGamePrice == input.BoardGamePrice), _cancellationToken))
                .ReturnsAsync(OneDayPrice);

            var result = await _sut.Handle(input, _cancellationToken);

            result.Count.Should().Be(days + 1);
            foreach (var rentalDay in result)
            {
                rentalDay.AmountDue.Should().Be(OneDayPrice);
                rentalDay.DayName.Should().Be(rentalDay.Day.DayOfWeek.ToString());
            }

            result.First().Day.Should().Be(startDate.Date);
            result.Last().Day.Should().Be(finishDate.Date);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(30)]
        [InlineData(59)]
        public async Task Handle_Should_ReturnEmptyList_When_RentAndReturnDateTimeIsExactlyTheSame(int secondsElapsedFromRentalStart)
        {
            var date = _actualTime.AddSeconds(-secondsElapsedFromRentalStart);
            var input = new GetRentalDaysQuery(15, date, date);

            var result = await _sut.Handle(input, _cancellationToken);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_Should_ReturnEmptyList_When_RentDateIsLessThenOneMinuteBiggerThenActualTime()
        {
            var date = _actualTime;
            var input = new GetRentalDaysQuery(15, date);

            var result = await _sut.Handle(input, _cancellationToken);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_Should_ReturnOneDay_When_RentDateIsMoreThenOneMinuteBiggerThenActualTime()
        {
            var date = _actualTime.AddMinutes(-1);
            var input = new GetRentalDaysQuery(15, date);

            var result = await _sut.Handle(input, _cancellationToken);

            result.First().Day.Should().Be(date.Date);
            result.First().DayName.Should().Be(date.DayOfWeek.ToString());
        }

        [Fact]
        public async Task Handle_Should_ReturnOneDay_When_ReturnIsAtLeaseOneMinuteBiggerThenRentDateTime()
        {
            var returnDate = _actualTime;
            var rentDate = returnDate.AddMinutes(-1);
            var input = new GetRentalDaysQuery(15, rentDate, returnDate);

            var result = await _sut.Handle(input, _cancellationToken);

            result.First().Day.Should().Be(rentDate.Date);
            result.First().DayName.Should().Be(rentDate.DayOfWeek.ToString());
        }
    }
}