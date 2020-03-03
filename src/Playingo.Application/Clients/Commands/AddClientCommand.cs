using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Validation;
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

        public Guid NewClientGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
    }

    internal class AddClientCommandHandler : ICommandHandler<AddClientCommand>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Client> _validator;

        public AddClientCommandHandler(IMediatorService mediatorService, IUnitOfWork unitOfWork,
            IValidator<Client> validator)
        {
            _mediatorService = mediatorService;
            _unitOfWork = unitOfWork;
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
                var validationMessage =
                    await _mediatorService.Send(new GetFormattedValidationMessageQuery(validationResult.Errors),
                        cancellationToken);
                throw new CustomValidationException(validationMessage);
            }
        }
    }
}