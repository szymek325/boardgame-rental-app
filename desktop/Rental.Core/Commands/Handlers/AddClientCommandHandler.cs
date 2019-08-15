using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Common;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models;
using Rental.Core.Models.Validation;
using Rental.Core.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class AddClientCommandHandler : AsyncRequestHandler<AddClientCommand>
    {
        private readonly IMediatorService _mediatorService;

        public AddClientCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(AddClientCommand command, CancellationToken cancellationToken)
        {
            var validator = new ClientValidator();
            var newClient = new Client(command.NewClientGuid, command.FirstName, command.LastName,
                command.ContactNumber,
                command.EmailAddress);
            var validationResult = validator.Validate(newClient);

            if (validationResult.IsValid)
                await _mediatorService.SendCommand(new AddAndSaveClientCommand(newClient), cancellationToken);

            var validationMessage =
                await _mediatorService.SendQuery(new GetFormattedValidationMessageQuery(validationResult.Errors),
                    cancellationToken);
            throw new ValidationException(validationMessage);
        }
    }
}