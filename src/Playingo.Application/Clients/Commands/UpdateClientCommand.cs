using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Common.Validation;
using Playingo.Domain.Clients;
using Playingo.Domain.Clients.Exceptions;

namespace Playingo.Application.Clients.Commands
{
    public class UpdateClientCommand : ICommand
    {
        public UpdateClientCommand(Guid id, string firstName, string lastName, string contactNumber,
            string emailAddress)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string ContactNumber { get; }
        public string EmailAddress { get; }
    }

    internal class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationMessageBuilder _validationMessageBuilder;
        private readonly IValidator<Client> _validator;

        public UpdateClientCommandHandler(IUnitOfWork unitOfWork, IValidationMessageBuilder validationMessageBuilder,
            IValidator<Client> validator)
        {
            _unitOfWork = unitOfWork;
            _validationMessageBuilder = validationMessageBuilder;
            _validator = validator;
        }

        public async Task Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(command.Id, cancellationToken);
            if (client == null)
                throw new ClientNotFoundException(command.Id);

            client.FirstName = command.FirstName;
            client.LastName = command.LastName;
            client.EmailAddress = command.EmailAddress;
            client.ContactNumber = command.ContactNumber;
            var validationResult = _validator.Validate(client);

            if (validationResult.IsValid)
            {
                await _unitOfWork.ClientRepository.Update(client);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            else
            {
                var validationMessage = _validationMessageBuilder.CreateMessage(validationResult.Errors);
                throw new CustomValidationException(validationMessage);
            }
        }
    }
}