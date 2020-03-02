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
using Playingo.Application.Queries;
using Playingo.Domain.BoardGames;
using Rental.CQS;
using Xunit;

namespace Rental.Core.Tests.Commands
{
    public class AddBoardGameCommandHandlerTests
    {
        public AddBoardGameCommandHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>(MockBehavior.Strict);
            _validator = new Mock<IValidator<BoardGame>>(MockBehavior.Strict);
            _sut = new AddBoardGameCommandHandler(_mediatorService.Object, _validator.Object);
        }

        private readonly Mock<IMediatorService> _mediatorService;
        private readonly Mock<IValidator<BoardGame>> _validator;
        private readonly ICommandHandler<AddBoardGameCommand> _sut;

        [Fact]
        public async Task Handle_Should_SendAddAndSaveCommand_When_ValidationIsPassed()
        {
            var input = new AddBoardGameCommand(Guid.NewGuid(), "name", 15);
            _validator.Setup(x => x.Validate(It.Is((BoardGame game) =>
                    game.Id == input.NewBoardGameGuid && game.Name == input.Name && game.Price == input.Price)))
                .Returns(new ValidationResult());
            var cancellationToken = new CancellationToken();
            _mediatorService.Setup(x =>
                x.Send(It.Is((AddAndSaveBoardGameCommand c) => c.BoardGame.Id == input.NewBoardGameGuid),
                    It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            await _sut.Handle(input, cancellationToken);

            _mediatorService.Verify(x =>
                x.Send(It.Is((AddAndSaveBoardGameCommand c) => c.BoardGame.Id == input.NewBoardGameGuid),
                    cancellationToken));
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_ValidatorReturnsValidationErrors()
        {
            var input = new AddBoardGameCommand(Guid.NewGuid(), "name", 15);
            var validationErrors = new List<ValidationFailure>
            {
                new ValidationFailure("test", "test")
            };
            _validator.Setup(x => x.Validate(It.Is((BoardGame game) =>
                    game.Id == input.NewBoardGameGuid && game.Name == input.Name && game.Price == input.Price)))
                .Returns(new ValidationResult(validationErrors));
            const string errorsMessage = "errors happened";
            _mediatorService.Setup(x =>
                x.Send(
                    It.Is((GetFormattedValidationMessageQuery query) =>
                        query.ValidationErrors.Count.Equals(validationErrors.Count)),
                    It.IsAny<CancellationToken>())).Returns(Task.FromResult(errorsMessage));

            Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());

            act.Should().Throw<CustomValidationException>().WithMessage(errorsMessage);
        }

        [Fact]
        public void Handle_Should_ThrowException_When_AddAndSaveBoardGameThrows()
        {
            var input = new AddBoardGameCommand(Guid.NewGuid(), "name", 15);
            var exception = new ArgumentException("test");
            _validator.Setup(x => x.Validate(It.IsAny<BoardGame>())).Returns(new ValidationResult());
            _mediatorService.Setup(x => x.Send(It.IsAny<AddAndSaveBoardGameCommand>(), It.IsAny<CancellationToken>()))
                .Throws(exception);

            Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());

            act.Should().Throw<ArgumentException>().WithMessage(exception.Message);
        }

        [Fact]
        public void Handle_Should_ThrowException_When_GetFormattedValidationMessageQueryThrows()
        {
            var input = new AddBoardGameCommand(Guid.NewGuid(), "name", 15);
            var exception = new ArgumentException("test");
            _validator.Setup(x => x.Validate(It.IsAny<BoardGame>())).Returns(new ValidationResult(
                new List<ValidationFailure>
                {
                    new ValidationFailure("test", "test")
                }));
            _mediatorService.Setup(x =>
                    x.Send(It.IsAny<GetFormattedValidationMessageQuery>(), It.IsAny<CancellationToken>()))
                .Throws(exception);

            Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());

            act.Should().Throw<ArgumentException>().WithMessage(exception.Message);
        }

        [Fact]
        public void Handle_Should_ThrowException_When_ValidatorThrows()
        {
            var input = new AddBoardGameCommand(Guid.NewGuid(), "name", 15);
            var exception = new ArgumentException("test");
            _validator.Setup(x => x.Validate(It.IsAny<BoardGame>())).Throws(exception);

            Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());

            act.Should().Throw<ArgumentException>().WithMessage(exception.Message);
        }
    }
}