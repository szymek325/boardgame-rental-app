using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rental.Core.Common.Exceptions;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.Core.Models.BoardGames;
using Rental.Core.Models.Clients;
using Rental.Core.Models.Rentals;
using Rental.Core.Queries;
using Rental.Core.Queries.Handlers;
using Rental.CQRS;
using Xunit;

namespace Rental.Core.Tests.Queries
{
    public class GetRentalWithPaymentDetailsQueryHandlerTests
    {
        public GetRentalWithPaymentDetailsQueryHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>(MockBehavior.Strict);
            _sut = new GetRentalWithPaymentDetailsQueryHandler(_mediatorService.Object);
        }

        private readonly CancellationToken _cancellationToken = new CancellationToken();
        private readonly Mock<IMediatorService> _mediatorService;
        private readonly IQueryHandler<GetRentalWithPaymentDetailsQuery, RentalWithPaymentDetails> _sut;

        [Fact]
        public async Task Handle_Should_ReturnRentalWithPaymentDetails_When_RentalExists()
        {
            var rentDay = DateTime.UtcNow.AddDays(-2);
            var boardGame = new BoardGame(Guid.NewGuid(), "SuperGame", 100);
            var client = new Client(Guid.NewGuid(), "Tom", "hanks", "12415421", "email@google.com");
            var rental = new RentalWithDetails(Guid.NewGuid(), 15, 0, Status.InProgress, rentDay, null, boardGame, client);
            _mediatorService.Setup(x => x.Send(new GetRentalWithDetailsQuery(rental.Id), _cancellationToken)).ReturnsAsync(rental);
            var rentalDays = new List<RentalDay>
            {
                new RentalDay(10, rentDay),
                new RentalDay(10, rentDay.AddDays(1)),
                new RentalDay(10, rentDay.AddDays(1))
            };
            _mediatorService
                .Setup(x => x.Send(new CalculateDailyRentalPaymentsQuery(rental.BoardGame.Price, rental.CreationTime), _cancellationToken))
                .ReturnsAsync(rentalDays);

            var result = await _sut.Handle(new GetRentalWithPaymentDetailsQuery(rental.Id), _cancellationToken);

            result.Should().BeOfType<RentalWithPaymentDetails>();
            result.RentalDays.Should().BeEquivalentTo(rentalDays);
            result.MoneyToPay.Should().Be(rentalDays.Sum(x => x.AmountDue));
        }

        [Fact]
        public void Handle_Should_Throw_When_CalculateDailyRentalPaymentsQueryThrows_()
        {
            var rentDay = DateTime.UtcNow.AddDays(-2);
            var boardGame = new BoardGame(Guid.NewGuid(), "SuperGame", 100);
            var client = new Client(Guid.NewGuid(), "Tom", "hanks", "12415421", "email@google.com");
            var rental = new RentalWithDetails(Guid.NewGuid(), 15, 0, Status.InProgress, rentDay, null, boardGame, client);
            _mediatorService.Setup(x => x.Send(new GetRentalWithDetailsQuery(rental.Id), _cancellationToken)).ReturnsAsync(rental);
            var exception = new ArgumentException("exception message long");
            _mediatorService
                .Setup(x => x.Send(new CalculateDailyRentalPaymentsQuery(rental.BoardGame.Price, rental.CreationTime), _cancellationToken))
                .ThrowsAsync(exception);

            Func<Task> act = async () => await _sut.Handle(new GetRentalWithPaymentDetailsQuery(rental.Id), _cancellationToken);

            act.Should().Throw<ArgumentException>().WithMessage(exception.Message);
        }

        [Fact]
        public void Handle_Should_ThrowRentalNotFound_When_GetRentalWithDetailsQueryReturnsNull()
        {
            var inputGuid = Guid.NewGuid();
            RentalWithDetails rental = null;
            _mediatorService.Setup(x => x.Send(new GetRentalWithDetailsQuery(rental.Id), _cancellationToken)).ReturnsAsync(rental);

            Func<Task> act = async () => await _sut.Handle(new GetRentalWithPaymentDetailsQuery(inputGuid), _cancellationToken);

            act.Should().Throw<RentalNotFoundException>();
        }
    }
}