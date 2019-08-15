using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models;
using Rental.Core.Models.Validation;
using Rental.Core.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class AddClientRequestHandler : AsyncRequestHandler<AddClientRequest>
    {
        private readonly IMediatorService _mediatorService;

        public AddClientRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(AddClientRequest request, CancellationToken cancellationToken)
        {
            var validator = new ClientValidator();
            var newClient = new Client(request.NewClientGuid, request.FirstName, request.LastName,
                request.ContactNumber,
                request.EmailAddress);
            var validationResult = validator.Validate(newClient);

            if (validationResult.IsValid)
                await _mediatorService.SendCommand(new AddAndSaveClientCommand(newClient), cancellationToken);

            var validationMessage =
                await _mediatorService.SendQuery(new GetFormattedValidationMessageRequest(validationResult.Errors),
                    cancellationToken);
            throw new ValidationException(validationMessage);
        }
    }
}