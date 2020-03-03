using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Rentals.Commands;
using Playingo.Domain;
using Playingo.Domain.Rentals;
using Xunit;

namespace Playingo.Application.Tests.Rentals.Commands
{
    public class CompleteRentalCommandHandlerTests
    {
        public CompleteRentalCommandHandlerTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _sut = new CompleteRentalCommandHandler(_unitOfWork.Object);
        }

        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly ICommandHandler<CompleteRentalCommand> _sut;
        private readonly CancellationToken _cancellationToken = new CancellationToken();

        [Theory]
        [InlineData(Status.Unknown)]
        [InlineData(Status.Completed)]
        public void Handle_Should_ThrowRentalIsNotInProgress_When_RentalStatusIsNotInProgress(Status status)
        {
            var input = new CompleteRentalCommand(Guid.NewGuid(), 15);
            var rental = new Rental(input.GameRentalId, Guid.NewGuid(), Guid.NewGuid(), 100)
                {Status = status};
            _unitOfWork.Setup(x =>
                    x.RentalRepository.GetByIdAsync(input.GameRentalId, _cancellationToken))
                .ReturnsAsync(rental);

            Func<Task> act = async () => await _sut.Handle(input, _cancellationToken);

            act.Should().Throw<RentalIsNotInProgressException>();
        }

        [Fact]
        public async Task Handle_Should_ChangeStatusToCompletedAndUpdateAndSaveRental_When_StatusIsInProgress()
        {
            var input = new CompleteRentalCommand(Guid.NewGuid(), 15);
            var rental = new Rental(input.GameRentalId, Guid.NewGuid(), Guid.NewGuid(), 100)
                {Status = Status.InProgress};
            _unitOfWork.Setup(x =>
                    x.RentalRepository.GetByIdAsync(input.GameRentalId, _cancellationToken))
                .ReturnsAsync(rental);
            _unitOfWork.Setup(x => x.RentalRepository.Update(rental)).Returns(Task.CompletedTask);
            _unitOfWork.Setup(x => x.SaveChangesAsync(_cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(input, _cancellationToken);

            _unitOfWork.Verify(x => x.RentalRepository.Update(rental), Times.Once);
            _unitOfWork.Verify(x => x.SaveChangesAsync(_cancellationToken), Times.Once);
            rental.Status.Should().Be(Status.Completed);
            rental.PaidMoney.Should().Be(input.PaidMoney);
        }

        [Fact]
        public void Handle_Should_ThrowRentalNotFoundException_When_RentalWithSpecifiedIdDoesNotExist()
        {
            var input = new CompleteRentalCommand(Guid.NewGuid(), 15);
            Rental rental = null;
            _unitOfWork.Setup(x =>
                    x.RentalRepository.GetByIdAsync(input.GameRentalId, _cancellationToken))
                .ReturnsAsync(rental);

            Func<Task> act = async () => await _sut.Handle(input, _cancellationToken);

            act.Should().Throw<RentalNotFoundException>();
        }
    }
}