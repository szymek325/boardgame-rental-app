﻿using System;
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

namespace Playingo.Application.Tests.BoardGames.Commands
{
    public class AddBoardGameCommandHandlerTests
    {
        public AddBoardGameCommandHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>(MockBehavior.Strict);
            _validator = new Mock<IValidator<BoardGame>>(MockBehavior.Strict);
            _unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _sut = new AddBoardGameCommandHandler(_mediatorService.Object, _unitOfWork.Object, _validator.Object);
        }

        private readonly Mock<IMediatorService> _mediatorService;
        private readonly Mock<IValidator<BoardGame>> _validator;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly ICommandHandler<AddBoardGameCommand> _sut;

        [Fact]
        public async Task Handle_Should_SaveBoardGame_When_ValidationIsPassed()
        {
            var input = new AddBoardGameCommand(Guid.NewGuid(), "name", 15);
            _validator.Setup(x => x.Validate(It.Is((BoardGame game) =>
                    game.Id == input.NewBoardGameGuid && game.Name == input.Name && game.Price == input.Price)))
                .Returns(new ValidationResult());
            var cancellationToken = new CancellationToken();
            _unitOfWork.Setup(x =>
                x.BoardGameRepository.AddAsync(It.Is((BoardGame b) => b.Id == input.NewBoardGameGuid),
                    cancellationToken)).Returns(Task.CompletedTask);
            _unitOfWork.Setup(x => x.SaveChangesAsync(cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(input, cancellationToken);

            _unitOfWork.Verify(
                x => x.BoardGameRepository.AddAsync(It.Is((BoardGame b) => b.Id == input.NewBoardGameGuid),
                    cancellationToken), Times.Once);
            _unitOfWork.Verify(x => x.SaveChangesAsync(cancellationToken), Times.Once);
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
        public void Handle_Should_ThrowException_When_SaveThrows()
        {
            var input = new AddBoardGameCommand(Guid.NewGuid(), "name", 15);
            var exception = new ArgumentException("test");
            var cancellationToken = new CancellationToken();
            _validator.Setup(x => x.Validate(It.IsAny<BoardGame>())).Returns(new ValidationResult());
            _unitOfWork.Setup(x =>
                x.BoardGameRepository.AddAsync(It.Is((BoardGame b) => b.Id == input.NewBoardGameGuid),
                    cancellationToken)).Returns(Task.CompletedTask);
            _unitOfWork.Setup(x => x.SaveChangesAsync(cancellationToken)).Throws(exception);

            Func<Task> act = async () => await _sut.Handle(input, cancellationToken);

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