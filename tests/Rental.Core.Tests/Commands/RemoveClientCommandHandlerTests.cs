using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Playingo.Application.Clients;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Domain.Clients;
using Xunit;

namespace Rental.Core.Tests.Commands
{
    public class RemoveClientCommandHandlerTests
    {
        public RemoveClientCommandHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>(MockBehavior.Strict);
            _sut = new RemoveClientCommandHandler(_mediatorService.Object);
        }

        private readonly CancellationToken _cancellationToken = new CancellationToken();
        private readonly RemoveClientCommand _inputCommand = new RemoveClientCommand(Guid.NewGuid());

        private readonly Mock<IMediatorService> _mediatorService;
        private readonly ICommandHandler<RemoveClientCommand> _sut;

        [Fact]
        public async Task Handle_Should_RemoveAndSaveBoardGame_When_GameCanBeRemoved()
        {
            var client = new Client(_inputCommand.Id, "first", "last", "12412", "email");
            _mediatorService
                .Setup(x => x.Send(It.Is((GetClientByIdQuery q) => q.Id == _inputCommand.Id), _cancellationToken))
                .ReturnsAsync(client);
            _mediatorService
                .Setup(x => x.Send(It.Is((CheckIfClientHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.Id),
                    _cancellationToken))
                .ReturnsAsync(true);
            _mediatorService
                .Setup(x => x.Send(It.Is((RemoveAndSaveClientByIdCommand c) => c.Id == _inputCommand.Id),
                    _cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, _cancellationToken);

            _mediatorService.Verify(x => x.Send(It.Is((RemoveAndSaveClientByIdCommand c) => c.Id == _inputCommand.Id),
                _cancellationToken), Times.Once);
        }

        [Fact]
        public void Handle_Should_ThrowClientNotFoundException_When_ClientWasNotFoundInDb()
        {
            Client client = null;
            _mediatorService
                .Setup(x => x.Send(It.Is((GetClientByIdQuery q) => q.Id == _inputCommand.Id), _cancellationToken))
                .ReturnsAsync(client);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().Throw<ClientNotFoundException>();
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_ClientHasInProgressRentals()
        {
            var client = new Client(_inputCommand.Id, "first", "last", "12412", "email");
            _mediatorService
                .Setup(x => x.Send(It.Is((GetClientByIdQuery q) => q.Id == _inputCommand.Id), _cancellationToken))
                .ReturnsAsync(client);
            _mediatorService
                .Setup(x => x.Send(It.Is((CheckIfClientHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.Id),
                    _cancellationToken))
                .ReturnsAsync(false);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().Throw<ClientHasOpenRentalException>();
        }
    }
}