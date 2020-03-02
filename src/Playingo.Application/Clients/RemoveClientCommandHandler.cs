using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Interfaces.DataAccess.Queries;

namespace Playingo.Application.Clients
{
    internal class RemoveClientCommandHandler : ICommandHandler<RemoveClientCommand>
    {
        private readonly IMediatorService _mediatorService;

        public RemoveClientCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task Handle(RemoveClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _mediatorService.Send(new GetClientByIdQuery(command.Id), cancellationToken);
            if (client == null)
                throw new ClientNotFoundException(command.Id);

            var hasOnlyCompletedRentals =
                await _mediatorService.Send(new CheckIfClientHasOnlyCompletedRentalsQuery(command.Id),
                    cancellationToken);
            if (!hasOnlyCompletedRentals)
                throw new ClientHasOpenRentalException(command.Id);

            await _mediatorService.Send(new RemoveAndSaveClientByIdCommand(command.Id), cancellationToken);
        }
    }
}