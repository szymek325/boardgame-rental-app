using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models.Validation;

namespace Rental.Core.Requests.Clients
{
    internal class UpdateClientRequestHandler : AsyncRequestHandler<UpdateClientRequest>
    {
        private readonly IMediatorService _mediatorService;

        public UpdateClientRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(UpdateClientRequest request, CancellationToken cancellationToken)
        {
            var client = await _mediatorService.SendQuery(new GetClientByIdQuery(request.Id), cancellationToken);
            client.FirstName = request.FirstName;
            client.LastName = request.LastName;
            client.EmailAddress = request.EmailAddress;
            client.ContactNumber = request.ContactNumber;
            var validator = new ClientValidator();
            var validationResult = validator.Validate(client);

            if (validationResult.IsValid)
                await _mediatorService.SendCommand(new UpdateAndSaveClientCommand(client), cancellationToken);

            var validationMessage =
                await _mediatorService.SendQuery(new GetFormattedValidationMessageRequest(validationResult.Errors),
                    cancellationToken);
            throw new ValidationException(validationMessage);
        }
    }
}