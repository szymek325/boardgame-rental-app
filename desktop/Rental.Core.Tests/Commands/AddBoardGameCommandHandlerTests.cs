using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Rental.Core.Commands;
using Rental.Core.Commands.Handlers;
using Rental.Core.Common.Exceptions;
using Rental.Core.Models;
using Rental.Core.Queries;
using Rental.CQRS;
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
        public void Handle_Should_ThrowCustomValidationException_When_ValidatorReturnsValidationErrors()
        {
            var input = new AddBoardGameCommand(Guid.NewGuid(), "name", 15);
            var validationErrors = new List<ValidationFailure>
            {
                new ValidationFailure("test", "test")
            };
            _validator.Setup(x => x.Validate(It.Is((BoardGame game) =>
                    game.Id == input.NewBoardGameGuid && game.Name == input.Name && game.Price == input.Price)))
                .Returns(new ValidationResult());
            var errorsMessage = "erros happend";
            _mediatorService.Setup(x =>
                x.Send(It.Is((GetFormattedValidationMessageQuery query) => query.ValidationErrors.Count.Equals(validationErrors.Count)),
                    It.IsAny<CancellationToken>())).Returns(Task.FromResult(errorsMessage));

            Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());

            act.Should().Throw<CustomValidationException>().WithMessage(errorsMessage);
        }

        [Fact]
        public void Handle_Should_SendAddAndSaveCommand_When_ValidationIsPassed()
        {
            var input = new AddBoardGameCommand(Guid.NewGuid(), "name", 15);
            _validator.Setup(x => x.Validate(It.Is((BoardGame game) =>
                    game.Id == input.NewBoardGameGuid && game.Name == input.Name && game.Price == input.Price)))
                .Returns(new ValidationResult(new List<ValidationFailure>
                {
                    new ValidationFailure("test","test")
                }));

            Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());

            act.Should().Throw<CustomValidationException>();
        }
    }
}