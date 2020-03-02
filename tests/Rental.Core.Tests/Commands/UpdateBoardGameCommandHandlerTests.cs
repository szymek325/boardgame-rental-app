using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Playingo.Application.BoardGames;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Application.Queries;
using Playingo.Domain.BoardGames;
using Rental.CQS;
using Xunit;

namespace Rental.Core.Tests.Commands
{
    public class UpdateBoardGameCommandHandlerTests
    {
        public UpdateBoardGameCommandHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>(MockBehavior.Strict);
            _validator = new Mock<IValidator<BoardGame>>(MockBehavior.Strict);
            _sut = new UpdateBoardGameCommandHandler(_mediatorService.Object, _validator.Object);
        }

        private readonly Mock<IMediatorService> _mediatorService;
        private readonly ICommandHandler<UpdateBoardGameCommand> _sut;
        private readonly Mock<IValidator<BoardGame>> _validator;

        private readonly UpdateBoardGameCommand _inputCommand =
            new UpdateBoardGameCommand(Guid.NewGuid(), "gameName", 125);

        private readonly CancellationToken _token = new CancellationToken();

        [Fact]
        public void Handle_Should_ThrowBoardGameNotFoundException_When_GetBoardGameByIdQueryReturnsNull()
        {
            BoardGame boardGame = null;
            _mediatorService.Setup(x => x.Send(It.Is((GetBoardGameByIdQuery q) => q.Id == _inputCommand.Id), _token))
                .ReturnsAsync(boardGame);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _token);

            act.Should().ThrowExactly<BoardGameNotFoundException>();
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_UpdatedBoardGameIsNotValid()
        {
            var boardGame = new BoardGame(_inputCommand.Id, "oldName", 15);
            _mediatorService.Setup(x => x.Send(It.Is((GetBoardGameByIdQuery q) => q.Id == _inputCommand.Id), _token))
                .ReturnsAsync(boardGame);
            var validationErrors = new List<ValidationFailure>
                {new ValidationFailure("price", "price error message")};
            _validator.Setup(x => x.Validate(boardGame)).Returns(new ValidationResult(validationErrors));
            const string errorMessage = "new error message";
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((GetFormattedValidationMessageQuery q) => q.ValidationErrors.Count == validationErrors.Count),
                    _token))
                .ReturnsAsync(errorMessage);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _token);

            act.Should().ThrowExactly<CustomValidationException>().WithMessage(errorMessage);
            boardGame.Name.Should().Be(_inputCommand.Name);
            boardGame.Price.Should().Be(_inputCommand.Price);
        }

        [Fact]
        public async Task Handle_Should_UpdateAndSaveBoardGame_When_ValidationIsPassed()
        {
            var boardGame = new BoardGame(_inputCommand.Id, "oldName", 15);
            _mediatorService.Setup(x => x.Send(It.Is((GetBoardGameByIdQuery q) => q.Id == _inputCommand.Id), _token))
                .ReturnsAsync(boardGame);
            _validator.Setup(x => x.Validate(boardGame)).Returns(new ValidationResult());
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((UpdateAndSaveBoardGameCommand c) => c.BoardGame == boardGame),
                    _token)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, _token);

            _mediatorService.Verify(
                x => x.Send(
                    It.Is((UpdateAndSaveBoardGameCommand c) =>
                        c.BoardGame.Id == _inputCommand.Id && c.BoardGame.Name == _inputCommand.Name &&
                        c.BoardGame.Price == _inputCommand.Price), _token), Times.Once());
        }
    }
}