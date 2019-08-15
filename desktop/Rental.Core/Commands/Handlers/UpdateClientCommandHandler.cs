using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Common;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models.Validation;
using Rental.Core.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class UpdateClientCommandHandler : AsyncRequestHandler<UpdateClientCommand>
    {
        private readonly IMediatorService _mediatorService;

        public UpdateClientCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _mediatorService.SendQuery(new GetClientByIdQuery(command.Id), cancellationToken);
            client.FirstName = command.FirstName;
            client.LastName = command.LastName;
            client.EmailAddress = command.EmailAddress;
            client.ContactNumber = command.ContactNumber;
            var validator = new ClientValidator();
            var validationResult = validator.Validate(client);

            if (validationResult.IsValid)
                await _mediatorService.SendCommand(new UpdateAndSaveClientCommand(client), cancellationToken);

            var validationMessage =
                await _mediatorService.SendQuery(new GetFormattedValidationMessageQuery(validationResult.Errors),
                    cancellationToken);
            throw new ValidationException(validationMessage);
        }
    }
}