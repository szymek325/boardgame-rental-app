using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Playingo.Application.Clients.Commands;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Common.Validation;
using Playingo.Domain.Clients;
using Xunit;

namespace Playingo.Application.Tests.Clients.Commands
{
    public class UpdateClientCommandHandlerTests
    {
        public UpdateClientCommandHandlerTests()
        {
            _validator = new Mock<IValidator<Client>>(MockBehavior.Strict);
            _unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _validationMessageBuilder = new Mock<IValidationMessageBuilder>(MockBehavior.Strict);
            _sut = new UpdateClientCommandHandler(_unitOfWork.Object, _validationMessageBuilder.Object,
                _validator.Object);
        }

        private readonly CancellationToken _cancellationToken = new CancellationToken();

        private readonly UpdateClientCommand _inputCommand =
            new UpdateClientCommand(Guid.NewGuid(), "new first name", "new last name", "48917", "newEmail@google.com");

        private readonly ICommandHandler<UpdateClientCommand> _sut;
        private readonly Mock<IValidator<Client>> _validator;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IValidationMessageBuilder> _validationMessageBuilder;

        [Fact]
        public void Handle_Should_ThrowClientNotFoundException_When_GetClientByIdQueryReturnsNull()
        {
            Client client = null;
            _unitOfWork.Setup(x => x.ClientRepository.GetByIdAsync(_inputCommand.Id, _cancellationToken))
                .ReturnsAsync(client);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().ThrowExactly<ClientNotFoundException>();
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_UpdatedBoardGameIsNotValid()
        {
            var client = new Client(_inputCommand.Id, "firstName", "lastName", "124", "email@google.com");
            _unitOfWork.Setup(x => x.ClientRepository.GetByIdAsync(_inputCommand.Id, _cancellationToken))
                .ReturnsAsync(client);
            var validationErrors = new List<ValidationFailure>
                {new ValidationFailure("contact number", "contact number error message")};
            _validator.Setup(x => x.Validate(client)).Returns(new ValidationResult(validationErrors));
            const string errorMessage = "new error message";
            _validationMessageBuilder.Setup(x => x.CreateMessage(validationErrors)).Returns(errorMessage);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().ThrowExactly<CustomValidationException>().WithMessage(errorMessage);
            client.FirstName.Should().Be(_inputCommand.FirstName);
            client.LastName.Should().Be(_inputCommand.LastName);
            client.ContactNumber.Should().Be(_inputCommand.ContactNumber);
            client.EmailAddress.Should().Be(_inputCommand.EmailAddress);
        }

        [Fact]
        public async Task Handle_Should_UpdateAndSaveBoardGame_When_ValidationIsPassed()
        {
            var client = new Client(_inputCommand.Id, "firstName", "lastName", "124", "email@google.com");
            _unitOfWork.Setup(x => x.ClientRepository.GetByIdAsync(_inputCommand.Id, _cancellationToken))
                .ReturnsAsync(client);
            _validator.Setup(x => x.Validate(client)).Returns(new ValidationResult());
            _unitOfWork.Setup(x => x.ClientRepository.Update(client))
                .Returns(Task.CompletedTask);
            _unitOfWork.Setup(x => x.SaveChangesAsync(_cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, _cancellationToken);

            _unitOfWork.Verify(
                x => x.ClientRepository.Update(
                    It.Is((Client c) =>
                        c.Id == _inputCommand.Id && c.FirstName == _inputCommand.FirstName &&
                        c.LastName == _inputCommand.LastName &&
                        c.ContactNumber == _inputCommand.ContactNumber &&
                        c.EmailAddress == _inputCommand.EmailAddress)), Times.Once());
            _unitOfWork.Verify(x => x.SaveChangesAsync(_cancellationToken), Times.Once);
        }
    }
}