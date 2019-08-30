using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Rental.Core.Common.Exceptions;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models.Clients;
using Rental.Core.Queries;
using Rental.CQS;

namespace Rental.Core.Commands.Handlers
{
    internal class AddClientCommandHandler : ICommandHandler<AddClientCommand>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IValidator<Client> _validator;

        public AddClientCommandHandler(IMediatorService mediatorService, IValidator<Client> validator)
        {
            _mediatorService = mediatorService;
            _validator = validator;
        }

        public async Task Handle(AddClientCommand command, CancellationToken cancellationToken)
        {
            var newClient = new Client(command.NewClientGuid, command.FirstName, command.LastName,
                command.ContactNumber,
                command.EmailAddress);
            var validationResult = _validator.Validate(newClient);

            if (validationResult.IsValid)
            {
                await _mediatorService.Send(new AddAndSaveClientCommand(newClient), cancellationToken);
            }
            else
            {
                var validationMessage =
                    await _mediatorService.Send(new GetFormattedValidationMessageQuery(validationResult.Errors),
                        cancellationToken);
                throw new CustomValidationException(validationMessage);
            }
        }
    }
}