using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Playingo.Application.BoardGames.Commands;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.BoardGames;
using Xunit;

namespace Rental.Core.Tests.BoardGames.Commands
{
    public class RemoveBoardGameCommandHandlerTests
    {
        public RemoveBoardGameCommandHandlerTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _sut = new RemoveBoardGameCommandHandler(_unitOfWork.Object);
        }

        private readonly CancellationToken _cancellationToken = new CancellationToken();
        private readonly RemoveBoardGameCommand _inputCommand = new RemoveBoardGameCommand(Guid.NewGuid());

        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly ICommandHandler<RemoveBoardGameCommand> _sut;

        [Fact]
        public async Task Handle_Should_RemoveAndSaveBoardGame_When_GameExistAndCanBeRemoved()
        {
            var boardGame = new BoardGame(_inputCommand.Id, "name", 15);
            _unitOfWork
                .Setup(x => x.BoardGameRepository.GetByIdAsync(_inputCommand.Id, _cancellationToken))
                .ReturnsAsync(boardGame);
            _unitOfWork
                .Setup(x => x.RentalRepository.AreAllCompletedForBoardGameAsync(boardGame.Id, _cancellationToken))
                .ReturnsAsync(true);
            _unitOfWork.Setup(x => x.BoardGameRepository.RemoveByIdAsync(boardGame.Id, _cancellationToken))
                .Returns(Task.CompletedTask);
            _unitOfWork.Setup(x => x.SaveChangesAsync(_cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, _cancellationToken);

            _unitOfWork.Verify(x => x.BoardGameRepository.RemoveByIdAsync(boardGame.Id, _cancellationToken),
                Times.Once);
            _unitOfWork.Verify(x => x.SaveChangesAsync(_cancellationToken), Times.Once);
        }

        [Fact]
        public void Handle_Should_ThrowBoardGameHasOpenRentalException_When_BoardGameWasNotFoundInDb()
        {
            BoardGame boardGame = null;
            _unitOfWork
                .Setup(x => x.BoardGameRepository.GetByIdAsync(_inputCommand.Id, _cancellationToken))
                .ReturnsAsync(boardGame);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().Throw<BoardGameNotFoundException>();
        }

        [Fact]
        public void Handle_Should_ThrowBoardGameHasOpenRentalException_When_GameHasRentalsInProgress()
        {
            var boardGame = new BoardGame(_inputCommand.Id, "name", 15);
            _unitOfWork
                .Setup(x => x.BoardGameRepository.GetByIdAsync(_inputCommand.Id, _cancellationToken))
                .ReturnsAsync(boardGame);
            _unitOfWork
                .Setup(x => x.RentalRepository.AreAllCompletedForBoardGameAsync(boardGame.Id, _cancellationToken))
                .ReturnsAsync(false);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().Throw<BoardGameHasOpenRentalException>();
        }
    }
}