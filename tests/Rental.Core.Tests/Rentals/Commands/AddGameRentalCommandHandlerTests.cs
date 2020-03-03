using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Rentals.Commands;
using Playingo.Application.Validation;
using Playingo.Domain.BoardGames;
using Playingo.Domain.Clients;
using Xunit;

namespace Rental.Core.Tests.Rentals.Commands
{
    public class AddGameRentalCommandHandlerTests
    {
        public AddGameRentalCommandHandlerTests()
        {
            _validator = new Mock<IValidator<Playingo.Domain.Rentals.Rental>>(MockBehavior.Strict);
            _validationMessageBuilder = new Mock<IValidationMessageBuilder>(MockBehavior.Strict);
            _unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _sut = new AddRentalCommandHandler(_unitOfWork.Object, _validationMessageBuilder.Object, _validator.Object);
        }

        private readonly AddRentalCommand _inputCommand =
            new AddRentalCommand(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 15);

        private readonly ICommandHandler<AddRentalCommand> _sut;
        private readonly Mock<IValidator<Playingo.Domain.Rentals.Rental>> _validator;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IValidationMessageBuilder> _validationMessageBuilder;

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
            _unitOfWork
                .Setup(x => x.ClientRepository.GetByIdAsync(_inputCommand.ClientGuid, cancellationToken))
                .ReturnsAsync(new Client(_inputCommand.ClientGuid, "First", "Last", "1234", "email"));
            BoardGame boardGame = null;
            _unitOfWork
                .Setup(x => x.BoardGameRepository.GetByIdAsync(_inputCommand.BoardGameGuid, cancellationToken))
                .ReturnsAsync(boardGame);
            _unitOfWork
                .Setup(x => x.RentalRepository.AreAllCompletedForBoardGameAsync(_inputCommand.BoardGameGuid,
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
            _unitOfWork
                .Setup(x => x.ClientRepository.GetByIdAsync(_inputCommand.ClientGuid, cancellationToken))
                .ReturnsAsync(client);
            _unitOfWork
                .Setup(x => x.BoardGameRepository.GetByIdAsync(_inputCommand.BoardGameGuid, cancellationToken))
                .ReturnsAsync(new BoardGame(_inputCommand.BoardGameGuid, "test", 15));
            _unitOfWork
                .Setup(x => x.RentalRepository.AreAllCompletedForBoardGameAsync(_inputCommand.BoardGameGuid,
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
            _unitOfWork
                .Setup(x => x.ClientRepository.GetByIdAsync(_inputCommand.ClientGuid, cancellationToken))
                .ReturnsAsync(new Client(_inputCommand.ClientGuid, "First", "Last", "1234", "email"));
            _unitOfWork
                .Setup(x => x.BoardGameRepository.GetByIdAsync(_inputCommand.BoardGameGuid, cancellationToken))
                .ReturnsAsync(new BoardGame(_inputCommand.BoardGameGuid, "test", 15));
            const bool canBeRented = true;
            _unitOfWork
                .Setup(x => x.RentalRepository.AreAllCompletedForBoardGameAsync(_inputCommand.BoardGameGuid,
                    cancellationToken)).ReturnsAsync(canBeRented);
            _unitOfWork.Setup(x => x.RentalRepository.AddAsync(
                It.Is((Playingo.Domain.Rentals.Rental c) =>
                    c.Id == _inputCommand.NewGameRentalGuid && c.ClientId == _inputCommand.ClientGuid &&
                    c.BoardGameId == _inputCommand.BoardGameGuid), cancellationToken)).Returns(Task.CompletedTask);
            _unitOfWork.Setup(x => x.SaveChangesAsync(cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, cancellationToken);

            _unitOfWork.Verify(
                x => x.RentalRepository.AddAsync(It.IsAny<Playingo.Domain.Rentals.Rental>(), cancellationToken),
                Times.Once);
            _unitOfWork.Verify(x => x.SaveChangesAsync(cancellationToken), Times.Once);
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
            _unitOfWork
                .Setup(x => x.ClientRepository.GetByIdAsync(_inputCommand.ClientGuid, cancellationToken))
                .ReturnsAsync(new Client(_inputCommand.ClientGuid, "First", "Last", "1234", "email"));
            _unitOfWork
                .Setup(x => x.BoardGameRepository.GetByIdAsync(_inputCommand.BoardGameGuid, cancellationToken))
                .ReturnsAsync(new BoardGame(_inputCommand.BoardGameGuid, "test", 15));
            const bool canBeRented = false;
            _unitOfWork
                .Setup(x => x.RentalRepository.AreAllCompletedForBoardGameAsync(_inputCommand.BoardGameGuid,
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
            _validationMessageBuilder.Setup(x => x.CreateMessage(validationErrors)).Returns(errorsMessage);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, cancellationToken);

            act.Should().Throw<CustomValidationException>().WithMessage(errorsMessage);
        }
    }
}