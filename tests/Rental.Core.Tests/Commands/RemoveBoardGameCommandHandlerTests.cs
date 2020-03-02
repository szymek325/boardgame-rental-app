using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Playingo.Application.BoardGames.Commands;
using Playingo.Application.BoardGames.Queries;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Domain.BoardGames;
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
        public async Task Handle_Should_RemoveAndSaveBoardGame_When_GameExistAndCanBeRemoved()
        {
            var boardGame = new BoardGame(_inputCommand.Id, "name", 15);
            _mediatorService
                .Setup(x => x.Send(It.Is((GetBoardGameByIdQuery q) => q.Id == _inputCommand.Id), _cancellationToken))
                .ReturnsAsync(boardGame);
            _mediatorService
                .Setup(x => x.Send(It.Is((CheckIfBoardGameHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.Id),
                    _cancellationToken))
                .ReturnsAsync(true);
            _mediatorService
                .Setup(x => x.Send(It.Is((RemoveAndSaveBoardGameByIdCommand c) => c.Id == _inputCommand.Id),
                    _cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, _cancellationToken);

            _mediatorService.Verify(x =>
                x.Send(It.Is((RemoveAndSaveBoardGameByIdCommand c) => c.Id == _inputCommand.Id),
                    _cancellationToken), Times.Once);
        }

        [Fact]
        public void Handle_Should_ThrowBoardGameHasOpenRentalException_When_BoardGameWasNotFoundInDb()
        {
            BoardGame boardGame = null;
            _mediatorService
                .Setup(x => x.Send(It.Is((GetBoardGameByIdQuery q) => q.Id == _inputCommand.Id), _cancellationToken))
                .ReturnsAsync(boardGame);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().Throw<BoardGameNotFoundException>();
        }

        [Fact]
        public void Handle_Should_ThrowBoardGameHasOpenRentalException_When_GameHasRentalsInProgress()
        {
            var boardGame = new BoardGame(_inputCommand.Id, "name", 15);
            _mediatorService
                .Setup(x => x.Send(It.Is((GetBoardGameByIdQuery q) => q.Id == _inputCommand.Id), _cancellationToken))
                .ReturnsAsync(boardGame);
            _mediatorService
                .Setup(x => x.Send(It.Is((CheckIfBoardGameHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.Id),
                    _cancellationToken))
                .ReturnsAsync(false);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().Throw<BoardGameHasOpenRentalException>();
        }
    }
}