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
using Rental.CQRS;
using Xunit;

namespace Rental.Core.Tests.Commands
{
    public class RemoveBoardGameCommandHandlerTests
    {
        public RemoveBoardGameCommandHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>(MockBehavior.Strict);
            _sut = new RemoveBoardGameCommandHandler(_mediatorService.Object);
        }

        private readonly CancellationToken _cancellationToken = new CancellationToken();
        private readonly RemoveBoardGameCommand _inputCommand = new RemoveBoardGameCommand(Guid.NewGuid());

        private readonly Mock<IMediatorService> _mediatorService;
        private readonly ICommandHandler<RemoveBoardGameCommand> _sut;

        [Fact]
        public async Task Handle_Should_RemoveAndSaveBoardGame_When_GameCanBeRemoved()
        {
            _mediatorService
                .Setup(x => x.Send(It.Is((CheckIfBoardGameHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.Id),
                    _cancellationToken))
                .ReturnsAsync(true);
            _mediatorService
                .Setup(x => x.Send(It.Is((RemoveAndSaveBoardGameCommand c) => c.Id == _inputCommand.Id),
                    _cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, _cancellationToken);

            _mediatorService.Verify(x => x.Send(It.Is((RemoveAndSaveBoardGameCommand c) => c.Id == _inputCommand.Id),
                _cancellationToken), Times.Once);
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_GameCanNotBeRemoved()
        {
            _mediatorService
                .Setup(x => x.Send(It.Is((CheckIfBoardGameHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.Id),
                    _cancellationToken))
                .ReturnsAsync(false);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().Throw<CustomValidationException>()
                .WithMessage($"BoardGame with id {_inputCommand.Id} can't be removed because of open rentals");
        }
    }
}