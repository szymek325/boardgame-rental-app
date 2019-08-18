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
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models;
using Rental.Core.Queries;
using Rental.CQRS;
using Xunit;

namespace Rental.Core.Tests.Commands
{
    public class AddClientCommandHandlerTests
    {
        public AddClientCommandHandlerTests()
        {
            _mediatorService = new Mock<IMediatorService>(MockBehavior.Strict);
            _validator = new Mock<IValidator<Client>>(MockBehavior.Strict);
            _sut = new AddClientCommandHandler(_mediatorService.Object, _validator.Object);
        }

        private readonly Mock<IMediatorService> _mediatorService;
        private readonly ICommandHandler<AddClientCommand> _sut;
        private readonly Mock<IValidator<Client>> _validator;

        private readonly AddClientCommand _inputCommand =
            new AddClientCommand(Guid.NewGuid(), "First Name", "Last Name", "123456", "email.google.pl");

        [Fact]
        public async Task Handle_Should_SendAddAndSaveCommand_When_ValidationIsPassed()
        {
            _validator.Setup(x => x.Validate(It.Is((Client client) => client.Id == _inputCommand.NewClientGuid)))
                .Returns(new ValidationResult());
            var cancellationToken = new CancellationToken();
            _mediatorService.Setup(x =>
                x.Send(It.Is((AddAndSaveClientCommand c) => c.Client.Id == _inputCommand.NewClientGuid),
                    It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            await _sut.Handle(_inputCommand, cancellationToken);

            _mediatorService.Verify(x =>
                x.Send(It.Is((AddAndSaveClientCommand c) => c.Client.Id == _inputCommand.NewClientGuid),
                    cancellationToken));
        }

        [Fact]
        public void Handle_Should_ThrowCustomValidationException_When_ValidatorReturnsValidationErrors()
        {
            var validationErrors = new List<ValidationFailure>
            {
                new ValidationFailure("test", "test")
            };
            _validator.Setup(x => x.Validate(It.Is((Client client) => client.Id == _inputCommand.NewClientGuid)))
                .Returns(new ValidationResult(validationErrors));
            const string errorsMessage = "errors happened";
            _mediatorService.Setup(x =>
                x.Send(
                    It.Is((GetFormattedValidationMessageQuery query) =>
                        query.ValidationErrors.Count.Equals(validationErrors.Count)),
                    It.IsAny<CancellationToken>())).Returns(Task.FromResult(errorsMessage));

            Func<Task> act = async () => await _sut.Handle(_inputCommand, new CancellationToken());

            act.Should().Throw<CustomValidationException>().WithMessage(errorsMessage);
        }

        [Fact]
        public void Handle_Should_ThrowException_When_AddAndSaveClientThrows()
        {
            var exception = new ArgumentException("test");
            _validator.Setup(x => x.Validate(It.IsAny<Client>())).Returns(new ValidationResult());
            _mediatorService.Setup(x => x.Send(It.IsAny<AddAndSaveClientCommand>(), It.IsAny<CancellationToken>()))
                .Throws(exception);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, new CancellationToken());

            act.Should().Throw<ArgumentException>().WithMessage(exception.Message);
        }

        [Fact]
        public void Handle_Should_ThrowException_When_GetFormattedValidationMessageQueryThrows()
        {
            var exception = new ArgumentException("test");
            _validator.Setup(x => x.Validate(It.IsAny<Client>())).Returns(new ValidationResult(
                new List<ValidationFailure>
                {
                    new ValidationFailure("test", "test")
                }));
            _mediatorService.Setup(x =>
                    x.Send(It.IsAny<GetFormattedValidationMessageQuery>(), It.IsAny<CancellationToken>()))
                .Throws(exception);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, new CancellationToken());

            act.Should().Throw<ArgumentException>().WithMessage(exception.Message);
        }

        [Fact]
        public void Handle_Should_ThrowException_When_ValidatorThrows()
        {
            var exception = new ArgumentException("test");
            _validator.Setup(x => x.Validate(It.IsAny<Client>())).Throws(exception);

            Func<Task> act = async () => await _sut.Handle(_inputCommand, new CancellationToken());

            act.Should().Throw<ArgumentException>().WithMessage(exception.Message);
        }
    }
}