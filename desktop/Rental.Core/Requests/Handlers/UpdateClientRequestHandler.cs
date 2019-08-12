using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.ClientRequests;
using Rental.Core.Models.Validation;

namespace Rental.Core.Requests.Handlers
{
    internal class UpdateClientRequestHandler : IRequestHandler<UpdateClientRequest, string>
    {
        private readonly IMediatorService _mediatorService;

        public UpdateClientRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task<string> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
        {
            var client = await _mediatorService.Request(new GetClientByIdRequest(request.Id), cancellationToken);
            client.FirstName = request.FirstName;
            client.LastName = request.LastName;
            client.EmailAddress = request.EmailAddress;
            client.ContactNumber = request.ContactNumber;
            var validator = new UpdateClientValidator();
            var validationResult = validator.Validate(client);

            if (validationResult.IsValid)
            {
                await _mediatorService.Notify(new UpdateAndSaveClientNotification(client), cancellationToken);
                return $"Client {client.Id} was successfully updated";
            }

            var validationMessage =
                await _mediatorService.Request(new GetFormattedValidationMessageRequest(validationResult.Errors),
                    cancellationToken);
            return $"Client {client.Id} was not successfully updated";
        }
    }
}