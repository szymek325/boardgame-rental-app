using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.ClientRequests;
using Rental.Core.Models;
using Rental.Core.Models.Validation;

namespace Rental.Core.Requests.Clients
{
    internal class AddClientRequestHandler : IRequestHandler<AddClientRequest, AddRequestResult>
    {
        private readonly IMediatorService _mediatorService;

        public AddClientRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task<AddRequestResult> Handle(AddClientRequest request, CancellationToken cancellationToken)
        {
            var validator = new ClientValidator();
            var newClient = new Client(request.FirstName, request.LastName, request.ContactNumber,
                request.EmailAddress);
            var validationResult = validator.Validate(newClient);
            if (validationResult.IsValid)
            {
                newClient.Id = Guid.NewGuid();
                await _mediatorService.Notify(new AddAndSaveClientNotification(newClient), cancellationToken);
                //await _mediatorService.Notify(new NewClientAddedNotification(newClient), cancellationToken);
                return new AddRequestResult(newClient.Id);
            }

            var validationMessage =
                await _mediatorService.Request(new GetFormattedValidationMessageRequest(validationResult.Errors),
                    cancellationToken);
            return new AddRequestResult(validationMessage);
        }
    }
}