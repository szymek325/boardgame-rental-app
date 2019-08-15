using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Common;
using Rental.Core.Common;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models;
using Rental.Core.Models.Validation;
using Rental.Core.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class AddClientCommandHandler : ICommandHandler<AddClientCommand>
    {
        private readonly IMediatorService _mediatorService;

        public AddClientCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public  async Task Handle(AddClientCommand command, CancellationToken cancellationToken)
        {
            var validator = new ClientValidator();
            var newClient = new Client(command.NewClientGuid, command.FirstName, command.LastName,
                command.ContactNumber,
                command.EmailAddress);
            var validationResult = validator.Validate(newClient);

            if (validationResult.IsValid)
                await _mediatorService.Send(new AddAndSaveClientCommand(newClient), cancellationToken);
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