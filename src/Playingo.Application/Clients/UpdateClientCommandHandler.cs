using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Application.Queries;
using Playingo.Domain.Clients;
using Rental.CQS;

namespace Playingo.Application.Clients
{
    internal class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IValidator<Client> _validator;

        public UpdateClientCommandHandler(IMediatorService mediatorService, IValidator<Client> validator)
        {
            _mediatorService = mediatorService;
            _validator = validator;
        }

        public async Task Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _mediatorService.Send(new GetClientByIdQuery(command.Id), cancellationToken);
            if (client == null)
                throw new ClientNotFoundException(command.Id);

            client.FirstName = command.FirstName;
            client.LastName = command.LastName;
            client.EmailAddress = command.EmailAddress;
            client.ContactNumber = command.ContactNumber;
            var validationResult = _validator.Validate(client);

            if (validationResult.IsValid)
            {
                await _mediatorService.Send(new UpdateAndSaveClientCommand(client), cancellationToken);
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