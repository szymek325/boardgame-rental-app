using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Application.Rentals;
using Playingo.Application.Validation;
using Playingo.Domain.BoardGames;
using Playingo.Domain.Clients;
using Xunit;

namespace Rental.Core.Tests.Commands
{
    public class AddGameRentalCommandHandlerTests
    {
        public AddGameRentalCommandHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>(MockBehavior.Strict);
            _validator = new Mock<IValidator<Playingo.Domain.Rentals.Rental>>(MockBehavior.Strict);
            _sut = new AddRentalCommandHandler(_mediatorService.Object, _validator.Object);
        }

        private readonly AddRentalCommand _inputCommand =
            new AddRentalCommand(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 15);

        private readonly Mock<IMediatorService> _mediatorService;
        private readonly ICommandHandler<AddRentalCommand> _sut;
        private readonly Mock<IValidator<Playingo.Domain.Rentals.Rental>> _validator;

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Handle_Should_ThrowBoardGameNotFoundException_When_ReturnedBoardGameIsNull(bool canBeRented)
        {
            _validator.Setup(
                    x => x.Validate(
                        It.Is((Playingo.Domain.Rentals.Rental rental) => rental.Id == _inputCommand.NewGameRentalGuid)))
                .Returns(new ValidationResult());
            var cancellationToken = new CancellationToken();
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((GetClientByIdQuery q) => q.Id == _inputCommand.ClientGuid),
                    cancellationToken))
                .ReturnsAsync(new Client(_inputCommand.ClientGuid, "First", "Last", "1234", "email"));
            BoardGame boardGame = null;
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((GetBoardGameByIdQuery q) => q.Id == _inputCommand.BoardGameGuid),
                    cancellationToken)).ReturnsAsync(boardGame);
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((CheckIfBoardGameHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.BoardGameGuid),
                    cancellationToken)).ReturnsAsync(canBeRented);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, cancellationToken);

            act.Should().Throw<BoardGameNotFoundException>();
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Handle_Should_ThrowClientNotFoundException_When_ReturnedClientIsNull(bool canBeRented)
        {
            _validator.Setup(
                    x => x.Validate(
                        It.Is((Playingo.Domain.Rentals.Rental rental) => rental.Id == _inputCommand.NewGameRentalGuid)))
                .Returns(new ValidationResult());
            var cancellationToken = new CancellationToken();
            Client client = null;
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((GetClientByIdQuery q) => q.Id == _inputCommand.ClientGuid),
                    cancellationToken)).ReturnsAsync(client);
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((GetBoardGameByIdQuery q) => q.Id == _inputCommand.BoardGameGuid),
                    cancellationToken)).ReturnsAsync(new BoardGame(_inputCommand.BoardGameGuid, "test", 15));
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((CheckIfBoardGameHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.BoardGameGuid),
                    cancellationToken)).ReturnsAsync(canBeRented);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, cancellationToken);

            act.Should().Throw<ClientNotFoundException>();
        }

        [Fact]
        public async Task Handle_Should_AddAndSaveRental_When_ValidationIsPassedAndGameCanBeRented()
        {
            _validator.Setup(
                    x => x.Validate(
                        It.Is((Playingo.Domain.Rentals.Rental rental) => rental.Id == _inputCommand.NewGameRentalGuid)))
                .Returns(new ValidationResult());
            var cancellationToken = new CancellationToken();
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((GetClientByIdQuery q) => q.Id == _inputCommand.ClientGuid),
                    cancellationToken))
                .ReturnsAsync(new Client(_inputCommand.ClientGuid, "First", "Last", "1234", "email"));
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((GetBoardGameByIdQuery q) => q.Id == _inputCommand.BoardGameGuid),
                    cancellationToken)).ReturnsAsync(new BoardGame(_inputCommand.BoardGameGuid, "test", 15));
            const bool canBeRented = true;
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((CheckIfBoardGameHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.BoardGameGuid),
                    cancellationToken)).ReturnsAsync(canBeRented);
            _mediatorService.Setup(x =>
                x.Send(It.Is((AddAndSaveRentalCommand c) => c.Rental.Id == _inputCommand.NewGameRentalGuid),
                    cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, cancellationToken);

            _mediatorService.Verify(x =>
                x.Send(It.Is((AddAndSaveRentalCommand c) => c.Rental.Id == _inputCommand.NewGameRentalGuid),
                    cancellationToken));
        }

        [Fact]
        public void
            Handle_Should_ThrowBoardGameHasOpenRentalException_When_ValidationIsPassedButBoardGameHasRentalInProgress()
        {
            _validator.Setup(
                    x => x.Validate(
                        It.Is((Playingo.Domain.Rentals.Rental rental) => rental.Id == _inputCommand.NewGameRentalGuid)))
                .Returns(new ValidationResult());
            var cancellationToken = new CancellationToken();
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((GetClientByIdQuery q) => q.Id == _inputCommand.ClientGuid),
                    cancellationToken))
                .ReturnsAsync(new Client(_inputCommand.ClientGuid, "First", "Last", "1234", "email"));
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((GetBoardGameByIdQuery q) => q.Id == _inputCommand.BoardGameGuid),
                    cancellationToken)).ReturnsAsync(new BoardGame(_inputCommand.BoardGameGuid, "test", 15));
            const bool canBeRented = false;
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((CheckIfBoardGameHasOnlyCompletedRentalsQuery q) => q.Id == _inputCommand.BoardGameGuid),
                    cancellationToken)).ReturnsAsync(canBeRented);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, cancellationToken);

            act.Should().Throw<BoardGameHasOpenRentalException>();
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_ValidatorReturnsValidationErrors()
        {
            var validationErrors = new List<ValidationFailure>
            {
                new ValidationFailure("test", "test")
            };
            _validator.Setup(x =>
                    x.Validate(It.Is((Playingo.Domain.Rentals.Rental gameRental) =>
                        gameRental.Id == _inputCommand.NewGameRentalGuid)))
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