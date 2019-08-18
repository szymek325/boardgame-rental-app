using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Rental.Core.Commands;
using Rental.Core.Commands.Handlers;
using Rental.Core.Common.Exceptions;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.Core.Queries;
using Rental.CQRS;
using Xunit;

namespace Rental.Core.Tests.Commands
{
    public class AddGameRentalCommandHandlerTests
    {
        public AddGameRentalCommandHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>(MockBehavior.Strict);
            _validator = new Mock<IValidator<GameRental>>(MockBehavior.Strict);
            _sut = new AddGameRentalCommandHandler(_mediatorService.Object, _validator.Object);
        }

        private readonly AddGameRentalCommand _inputCommand =
            new AddGameRentalCommand(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 15);

        private readonly Mock<IMediatorService> _mediatorService;
        private readonly ICommandHandler<AddGameRentalCommand> _sut;
        private readonly Mock<IValidator<GameRental>> _validator;

        [Fact]
        public async Task Handle_Should_AddAndSaveRental_When_ValidationIsPassedAndGameCanBeRented()
        {
            _validator.Setup(
                    x => x.Validate(It.Is((GameRental rental) => rental.Id == _inputCommand.NewGameRentalGuid)))
                .Returns(new ValidationResult());
            var cancellationToken = new CancellationToken();
            const bool canBeRented = true;
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((CheckIfBoardGameHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.BoardGameGuid),
                    cancellationToken)).ReturnsAsync(canBeRented);
            _mediatorService.Setup(x =>
                x.Send(It.Is((AddAndSaveRentalCommand c) => c.GameRental.Id == _inputCommand.NewGameRentalGuid),
                    cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, cancellationToken);

            _mediatorService.Verify(x =>
                x.Send(It.Is((AddAndSaveRentalCommand c) => c.GameRental.Id == _inputCommand.NewGameRentalGuid),
                    cancellationToken));
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_ValidationIsPassedButBoardGameCanNotBeRented()
        {
            _validator.Setup(
                    x => x.Validate(It.Is((GameRental rental) => rental.Id == _inputCommand.NewGameRentalGuid)))
                .Returns(new ValidationResult());
            var cancellationToken = new CancellationToken();
            const bool canBeRented = false;
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((CheckIfBoardGameHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.BoardGameGuid),
                    cancellationToken)).ReturnsAsync(canBeRented);
            const string errorMessage = "formatted error message";
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((GetFormattedValidationMessageQuery c) =>
                        c.ValidationErrors.First().PropertyName == nameof(GameRental.BoardGameId)), cancellationToken))
                .ReturnsAsync(errorMessage);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, cancellationToken);

            act.Should().Throw<CustomValidationException>().WithMessage(errorMessage);
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_ValidatorReturnsValidationErrors()
        {
            var validationErrors = new List<ValidationFailure>
            {
                new ValidationFailure("test", "test")
            };
            _validator.Setup(x =>
                    x.Validate(It.Is((GameRental gameRental) => gameRental.Id == _inputCommand.NewGameRentalGuid)))
                .Returns(new ValidationResult(validationErrors));
            const string errorsMessage = "errors happened";
            var cancellationToken = new CancellationToken();
            _mediatorService.Setup(x =>
                x.Send(It.Is((GetFormattedValidationMessageQuery query) =>
                        query.ValidationErrors.Count.Equals(validationErrors.Count)),
                    cancellationToken)).Returns(Task.FromResult(errorsMessage));

            Func<Task> act = async () => await _sut.Handle(_inputCommand, cancellationToken);

            act.Should().Throw<CustomValidationException>().WithMessage(errorsMessage);
        }
    }
}