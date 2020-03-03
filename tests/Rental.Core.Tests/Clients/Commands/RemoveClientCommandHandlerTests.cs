using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Playingo.Application.Clients.Commands;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Clients;
using Xunit;

namespace Rental.Core.Tests.Clients.Commands
{
    public class RemoveClientCommandHandlerTests
    {
        public RemoveClientCommandHandlerTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _sut = new RemoveClientCommandHandler(_unitOfWork.Object);
        }

        private readonly CancellationToken _cancellationToken = new CancellationToken();
        private readonly RemoveClientCommand _inputCommand = new RemoveClientCommand(Guid.NewGuid());

        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly ICommandHandler<RemoveClientCommand> _sut;

        [Fact]
        public async Task Handle_Should_RemoveAndSaveBoardGame_When_GameCanBeRemoved()
        {
            var client = new Client(_inputCommand.Id, "first", "last", "12412", "email");
            _unitOfWork
                .Setup(x => x.ClientRepository.GetByIdAsync(_inputCommand.Id, _cancellationToken))
                .ReturnsAsync(client);
            _unitOfWork
                .Setup(x => x.RentalRepository.AreAllCompletedForClientAsync(client.Id, _cancellationToken))
                .ReturnsAsync(true);
            _unitOfWork.Setup(x => x.ClientRepository.RemoveByIdAsync(client.Id, _cancellationToken))
                .Returns(Task.CompletedTask);
            _unitOfWork.Setup(x => x.SaveChangesAsync(_cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, _cancellationToken);

            _unitOfWork.Verify(x => x.ClientRepository.RemoveByIdAsync(client.Id, _cancellationToken),
                Times.Once);
            _unitOfWork.Verify(x => x.SaveChangesAsync(_cancellationToken), Times.Once);
        }

        [Fact]
        public void Handle_Should_ThrowClientNotFoundException_When_ClientWasNotFoundInDb()
        {
            Client client = null;
            _unitOfWork
                .Setup(x => x.ClientRepository.GetByIdAsync(_inputCommand.Id, _cancellationToken))
                .ReturnsAsync(client);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().Throw<ClientNotFoundException>();
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_ClientHasInProgressRentals()
        {
            var client = new Client(_inputCommand.Id, "first", "last", "12412", "email");
            _unitOfWork
                .Setup(x => x.ClientRepository.GetByIdAsync(_inputCommand.Id, _cancellationToken))
                .ReturnsAsync(client);
            _unitOfWork
                .Setup(x => x.RentalRepository.AreAllCompletedForClientAsync(client.Id, _cancellationToken))
                .ReturnsAsync(false);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().Throw<ClientHasOpenRentalException>();
        }
    }
}