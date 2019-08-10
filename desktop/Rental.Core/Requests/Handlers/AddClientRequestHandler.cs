using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.ClientRequests;
using Rental.Core.Models;
using Rental.Core.Models.Validation;

namespace Rental.Core.Requests.Handlers
{
    internal class AddClientRequestHandler : IRequestHandler<AddClientRequest, Guid>
    {
        private readonly IMediatorService _mediatorService;

        public AddClientRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task<Guid> Handle(AddClientRequest request, CancellationToken cancellationToken)
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
                return newClient.Id;
            }

            var builder = new StringBuilder();
            foreach (var validationFailure in validationResult.Errors)
                builder.AppendLine($"{validationFailure.PropertyName}- {validationFailure.ErrorMessage}");
            Trace.WriteLine(builder.ToString());
            return Guid.Empty;
        }
    }
}