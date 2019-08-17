using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models.Validation;
using Rental.Core.Queries;
using Rental.CQRS;

namespace Rental.Core.Commands.Handlers
{
    internal class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand>
    {
        private readonly IMediatorService _mediatorService;

        public UpdateClientCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _mediatorService.Send(new GetClientByIdQuery(command.Id), cancellationToken);
            if (client == null)
                throw new ValidationException($"Client with id {command.Id} doesn't exist");

            client.FirstName = command.FirstName;
            client.LastName = command.LastName;
            client.EmailAddress = command.EmailAddress;
            client.ContactNumber = command.ContactNumber;
            var validator = new ClientValidator();
            var validationResult = validator.Validate(client);

            if (validationResult.IsValid)
            {
                await _mediatorService.Send(new UpdateAndSaveClientCommand(client), cancellationToken);
            }
            else
            {
                var validationMessage =
                    await _mediatorService.Send(new GetFormattedValidationMessageQuery(validationResult.Errors),
                        cancellationToken);
                throw new ValidationException(validationMessage);
            }
        }
    }
}