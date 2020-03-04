using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Common.Validation;
using Playingo.Domain.Clients;

namespace Playingo.Application.Clients.Commands
{
    public class AddClientCommand : ICommand
    {
        public AddClientCommand(Guid newClientGuid, string firstName, string lastName, string contactNumber,
            string emailAddress)
        {
            NewClientGuid = newClientGuid;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
        }

        public Guid NewClientGuid { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string ContactNumber { get; }
        public string EmailAddress { get; }
    }

    internal class AddClientCommandHandler : ICommandHandler<AddClientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationMessageBuilder _validationMessageBuilder;
        private readonly IValidator<Client> _validator;

        public AddClientCommandHandler(IUnitOfWork unitOfWork, IValidationMessageBuilder validationMessageBuilder,
            IValidator<Client> validator)
        {
            _unitOfWork = unitOfWork;
            _validationMessageBuilder = validationMessageBuilder;
            _validator = validator;
        }


        public async Task Handle(AddClientCommand command, CancellationToken cancellationToken)
        {
            var newClient = new Client(command.NewClientGuid, command.FirstName, command.LastName,
                command.ContactNumber,
                command.EmailAddress);
            var validationResult = _validator.Validate(newClient);

            if (validationResult.IsValid)
            {
                await _unitOfWork.ClientRepository.AddAsync(newClient, cancellationToken);
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