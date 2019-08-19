using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Rental.Core.Common.Exceptions;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models.Clients;
using Rental.Core.Queries;
using Rental.CQRS;

namespace Rental.Core.Commands.Handlers
{
    internal class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IValidator<Client> _validator;

        public UpdateClientCommandHandler(IMediatorService mediatorService, IValidator<Client> validator)
        {
            _mediatorService = mediatorService;
            _validator = validator;
        }

        public async Task Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _mediatorService.Send(new GetClientByIdQuery(command.Id), cancellationToken);
            if (client == null)
                throw new ClientNotFoundException(command.Id);

            client.FirstName = command.FirstName;
            client.LastName = command.LastName;
            client.EmailAddress = command.EmailAddress;
            client.ContactNumber = command.ContactNumber;
            var validationResult = _validator.Validate(client);

            if (validationResult.IsValid)
            {
                await _mediatorService.Send(new UpdateAndSaveClientCommand(client), cancellationToken);
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