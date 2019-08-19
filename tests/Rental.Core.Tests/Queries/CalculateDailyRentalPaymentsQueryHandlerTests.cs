using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Rental.Core.Models.Rentals;
using Rental.Core.Queries;
using Rental.Core.Queries.Handlers;
using Rental.CQRS;
using Xunit;

namespace Rental.Core.Tests.Queries
{
    public class CalculateDailyRentalPaymentsQueryHandlerTests
    {
        //TODO refactor after date time provider added
        public CalculateDailyRentalPaymentsQueryHandlerTests()
        {
            _sut = new CalculateDailyRentalPaymentsQueryHandler();
        }

        private readonly CancellationToken _cancellationToken = new CancellationToken();
        private readonly IQueryHandler<CalculateDailyRentalPaymentsQuery, IList<RentalDay>> _sut;

        public static IEnumerable<object[]> NumberOfDaysRange =>
            Enumerable.Range(1, 10).Select(x => new[] {(object) x}).ToList();

        [Theory]
        [MemberData(nameof(NumberOfDaysRange))]
        public async Task Handle_Should_ReturnRentalDayForEachPassedDayUntilToday_When_FinishDateIsNotPassed(int days)
        {
            var today = DateTime.UtcNow;
            var startDate = today.AddDays(-days);
            var input = new CalculateDailyRentalPaymentsQuery(15, startDate);
            //TODO should be returned by another query
            var dailyPrice = 7 / 100 * input.BoardGamePrice;

            var result = await _sut.Handle(input, _cancellationToken);

            result.Count.Should().Be(days);
            foreach (var rentalDay in result)
            {
                rentalDay.AmountDue.Should().Be(dailyPrice);
                rentalDay.DayName.Should().Be(rentalDay.Day.DayOfWeek.ToString());
            }
        }

        [Theory]
        [MemberData(nameof(NumberOfDaysRange))]
        public async Task Handle_Should_ReturnRentalDayForEachPassedDayUntilFinishDate_When_FinishDateIsPassed(int days)
        {
            var finishDate = DateTime.UtcNow;
            var startDate = finishDate.AddDays(-days);
            var input = new CalculateDailyRentalPaymentsQuery(15, startDate, finishDate);
            //TODO should be returned by another query
            var dailyPrice = 7 / 100 * input.BoardGamePrice;

            var result = await _sut.Handle(input, _cancellationToken);

            result.Count.Should().Be(days);
            foreach (var rentalDay in result)
            {
                rentalDay.AmountDue.Should().Be(dailyPrice);
                rentalDay.DayName.Should().Be(rentalDay.Day.DayOfWeek.ToString());
            }
        }

        [Fact]
        public async Task Handle_Should_ReturnEmptyList_When_RentAndReturnDateTimeIsExactlyTheSame()
        {
            var date = DateTime.UtcNow;
            var input = new CalculateDailyRentalPaymentsQuery(15, date, date);

            var result = await _sut.Handle(input, _cancellationToken);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_Should_ReturnEmptyList_When_RentDateIsLessThenOneMinuteBiggerThenActualTime()
        {
            var date = DateTime.UtcNow;
            var input = new CalculateDailyRentalPaymentsQuery(15, date);

            var result = await _sut.Handle(input, _cancellationToken);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_Should_ReturnOneDay_When_RentDateIsMoreThenOneMinuteBiggerThenActualTime()
        {
            var date = DateTime.UtcNow.AddMinutes(-1);
            var input = new CalculateDailyRentalPaymentsQuery(15, date);

            var result = await _sut.Handle(input, _cancellationToken);

            result.First().Day.Should().Be(date.Date);
            result.First().DayName.Should().Be(date.DayOfWeek.ToString());
        }

        [Fact]
        public async Task Handle_Should_ReturnOneDay_When_ReturnIsAtLeaseOneMinuteBiggerThenRentDateTime()
        {
            var returnDate = DateTime.UtcNow;
            var rentDate = returnDate.AddMinutes(-1);
            var input = new CalculateDailyRentalPaymentsQuery(15, rentDate, returnDate);

            var result = await _sut.Handle(input, _cancellationToken);

            result.First().Day.Should().Be(rentDate.Date);
            result.First().DayName.Should().Be(rentDate.DayOfWeek.ToString());
        }
    }
}