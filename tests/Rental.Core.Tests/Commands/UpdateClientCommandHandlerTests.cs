using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Playingo.Application.Clients;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Application.Validation;
using Playingo.Domain.Clients;
using Xunit;

namespace Rental.Core.Tests.Commands
{
    public class UpdateClientCommandHandlerTests
    {
        public UpdateClientCommandHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>(MockBehavior.Strict);
            _validator = new Mock<IValidator<Client>>(MockBehavior.Strict);
            _sut = new UpdateClientCommandHandler(_mediatorService.Object, _validator.Object);
        }

        private readonly CancellationToken _cancellationToken = new CancellationToken();

        private readonly UpdateClientCommand _inputCommand =
            new UpdateClientCommand(Guid.NewGuid(), "new first name", "new last name", "48917", "newEmail@google.com");

        private readonly Mock<IMediatorService> _mediatorService;
        private readonly ICommandHandler<UpdateClientCommand> _sut;
        private readonly Mock<IValidator<Client>> _validator;

        [Fact]
        public void Handle_Should_ThrowClientNotFoundException_When_GetClientByIdQueryReturnsNull()
        {
            Client client = null;
            _mediatorService.Setup(x =>
                    x.Send(It.Is((GetClientByIdQuery q) => q.Id == _inputCommand.Id), _cancellationToken))
                .ReturnsAsync(client);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, _cancellationToken);

            act.Should().ThrowExactly<ClientNotFoundException>();
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_UpdatedBoardGameIsNotValid()
        {
            var client = new Client(_inputCommand.Id, "firstName", "lastName", "124", "email@google.com");
            _mediatorService.Setup(x =>
                    x.Send(It.Is((GetClientByIdQuery q) => q.Id == _inputCommand.Id), _cancellationToken))
                .ReturnsAsync(client);
            var validationErrors = new List<ValidationFailure>
                {new ValidationFailure("contact number", "contact number error message")};
            _validator.Setup(x => x.Validate(client)).Returns(new ValidationResult(validationErrors));
            const string errorMessage = "new error message";
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((GetFormattedValidationMessageQuery q) => q.ValidationErrors.Count == validationErrors.Count),
                    _cancellationToken))
                .ReturnsAsync(errorMessage);

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
            _mediatorService.Setup(x =>
                    x.Send(It.Is((GetClientByIdQuery q) => q.Id == _inputCommand.Id), _cancellationToken))
                .ReturnsAsync(client);
            _validator.Setup(x => x.Validate(client)).Returns(new ValidationResult());
            _mediatorService
                .Setup(x => x.Send(
                    It.Is((UpdateAndSaveClientCommand c) => c.Client == client),
                    _cancellationToken)).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, _cancellationToken);

            _mediatorService.Verify(
                x => x.Send(
                    It.Is((UpdateAndSaveClientCommand c) =>
                        c.Client.Id == _inputCommand.Id && c.Client.FirstName == _inputCommand.FirstName &&
                        c.Client.LastName == _inputCommand.LastName &&
                        c.Client.ContactNumber == _inputCommand.ContactNumber &&
                        c.Client.EmailAddress == _inputCommand.EmailAddress), _cancellationToken), Times.Once());
        }
    }
}