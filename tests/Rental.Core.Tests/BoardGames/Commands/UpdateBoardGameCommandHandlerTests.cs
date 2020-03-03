using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Playingo.Application.BoardGames.Commands;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Validation;
using Playingo.Domain.BoardGames;
using Xunit;

namespace Rental.Core.Tests.BoardGames.Commands
{
    public class UpdateBoardGameCommandHandlerTests
    {
        public UpdateBoardGameCommandHandlerTests()
        {
            _validator = new Mock<IValidator<BoardGame>>(MockBehavior.Strict);
            _unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _validationMessageBuilder = new Mock<IValidationMessageBuilder>(MockBehavior.Strict);
            _sut = new UpdateBoardGameCommandHandler(_unitOfWork.Object, _validationMessageBuilder.Object,
                _validator.Object);
        }

        private readonly ICommandHandler<UpdateBoardGameCommand> _sut;
        private readonly Mock<IValidator<BoardGame>> _validator;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IValidationMessageBuilder> _validationMessageBuilder;

        private readonly UpdateBoardGameCommand _inputCommand =
            new UpdateBoardGameCommand(Guid.NewGuid(), "gameName", 125);

        private readonly CancellationToken _token = new CancellationToken();

        [Fact]
        public void Handle_Should_ThrowBoardGameNotFoundException_When_GetBoardGameByIdQueryReturnsNull()
        {
            BoardGame boardGame = null;
            _unitOfWork.Setup(x => x.BoardGameRepository.GetByIdAsync(_inputCommand.Id, _token))
                .ReturnsAsync(boardGame);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _token);

            act.Should().ThrowExactly<BoardGameNotFoundException>();
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_UpdatedBoardGameIsNotValid()
        {
            var boardGame = new BoardGame(_inputCommand.Id, "oldName", 15);
            _unitOfWork.Setup(x => x.BoardGameRepository.GetByIdAsync(_inputCommand.Id, _token))
                .ReturnsAsync(boardGame);
            var validationErrors = new List<ValidationFailure>
                {new ValidationFailure("price", "price error message")};
            _validator.Setup(x => x.Validate(boardGame)).Returns(new ValidationResult(validationErrors));
            const string errorMessage = "new error message";
            _validationMessageBuilder.Setup(x => x.CreateMessage(validationErrors)).Returns(errorMessage);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _token);

            act.Should().ThrowExactly<CustomValidationException>().WithMessage(errorMessage);
            boardGame.Name.Should().Be(_inputCommand.Name);
            boardGame.Price.Should().Be(_inputCommand.Price);
        }

        [Fact]
        public async Task Handle_Should_UpdateAndSaveBoardGame_When_ValidationIsPassed()
        {
            var boardGame = new BoardGame(_inputCommand.Id, "oldName", 15);
            _unitOfWork.Setup(x => x.BoardGameRepository.GetByIdAsync(_inputCommand.Id, _token))
                .ReturnsAsync(boardGame);
            _validator.Setup(x => x.Validate(boardGame)).Returns(new ValidationResult());
            _unitOfWork.Setup(x => x.BoardGameRepository.Update(boardGame))
                .Returns(Task.CompletedTask);
            _unitOfWork.Setup(x => x.SaveChangesAsync(_token)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, _token);

            _unitOfWork.Verify(
                x => x.BoardGameRepository.Update(
                    It.Is((BoardGame c) =>
                        c.Id == _inputCommand.Id && c.Name == _inputCommand.Name &&
                        c.Price == _inputCommand.Price)), Times.Once());
            _unitOfWork.Verify(x => x.SaveChangesAsync(_token), Times.Once);
        }
    }
}