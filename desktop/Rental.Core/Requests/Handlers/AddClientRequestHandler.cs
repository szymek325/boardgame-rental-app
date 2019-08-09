using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess;
using Rental.Core.Interfaces.DataAccess.Client;
using Rental.Core.Models.Validation;
using Rental.Core.Notifications;

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
            var validationResult = validator.Validate(request.Client);
            if (validationResult.IsValid)
            {
                var response = await _mediatorService.Request(new AddAndSaveClientRequest(request.Client));
                await _mediatorService.Notify(new NewClientAddedNotification(request.Client));
                return response.Id;
            }

            var builder = new StringBuilder();
            foreach (var validationFailure in validationResult.Errors)
                builder.AppendLine($"{validationFailure.PropertyName}- {validationFailure.ErrorMessage}");
            Trace.WriteLine(builder.ToString());
            return Guid.Empty;
        }
    }
}