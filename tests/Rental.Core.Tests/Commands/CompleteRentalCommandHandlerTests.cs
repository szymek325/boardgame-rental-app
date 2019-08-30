using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rental.Core.Commands;
using Rental.Core.Commands.Handlers;
using Rental.Core.Common.Exceptions;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.CQS;
using Xunit;

namespace Rental.Core.Tests.Commands
{
    public class CompleteRentalCommandHandlerTests
    {
        public CompleteRentalCommandHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>();
            _sut = new CompleteRentalCommandHandler(_mediatorService.Object);
        }

        private readonly Mock<IMediatorService> _mediatorService;
        private readonly ICommandHandler<CompleteRentalCommand> _sut;
        private readonly CancellationToken _cancellationToken = new CancellationToken();

        [Theory]
        [InlineData(Status.Unknown)]
        [InlineData(Status.Completed)]
        public void Handle_Should_ThrowRentalIsNotInProgress_When_RentalStatusIsNotInProgress(Status status)
        {
            var input = new CompleteRentalCommand(Guid.NewGuid(), 15);
            var rental = new Models.Rentals.Rental(input.GameRentalId, Guid.NewGuid(), Guid.NewGuid(), 100) {Status = status};
            _mediatorService.Setup(x => x.Send(It.Is<GetRentalByIdQuery>(q => q.Id == input.GameRentalId), _cancellationToken))
                .ReturnsAsync(rental);

            Func<Task> act = async () => await _sut.Handle(input, _cancellationToken);

            act.Should().Throw<RentalIsNotInProgressException>();
        }

        [Fact]
        public async Task Handle_Should_ChangeStatusToCompletedAndUpdateAndSaveRental_When_StatusIsInProgress()
        {
            var input = new CompleteRentalCommand(Guid.NewGuid(), 15);
            var rental = new Models.Rentals.Rental(input.GameRentalId, Guid.NewGuid(), Guid.NewGuid(), 100) {Status = Status.InProgress};
            _mediatorService.Setup(x => x.Send(It.Is<GetRentalByIdQuery>(q => q.Id == input.GameRentalId), _cancellationToken))
                .ReturnsAsync(rental);
            _mediatorService.Setup(x => x.Send(It.IsAny<UpdateAndSaveGameRentalCommand>(), _cancellationToken));

            await _sut.Handle(input, _cancellationToken);

            _mediatorService.Verify(
                x => x.Send(
                    It.Is<UpdateAndSaveGameRentalCommand>(c =>
                        c.Rental.Id == input.GameRentalId && c.Rental.Status == Status.Completed && c.Rental.PaidMoney == input.PaidMoney),
                    _cancellationToken), Times.Once);
            rental.Status.Should().Be(Status.Completed);
            rental.PaidMoney.Should().Be(input.PaidMoney);
        }

        [Fact]
        public void Handle_Should_ThrowRentalNotFoundException_When_RentalWithSpecifiedIdDoesNotExist()
        {
            var input = new CompleteRentalCommand(Guid.NewGuid(), 15);
            Models.Rentals.Rental rental = null;
            _mediatorService.Setup(x => x.Send(It.Is<GetRentalByIdQuery>(q => q.Id == input.GameRentalId), _cancellationToken))
                .ReturnsAsync(rental);

            Func<Task> act = async () => await _sut.Handle(input, _cancellationToken);

            act.Should().Throw<RentalNotFoundException>();
        }
    }
}