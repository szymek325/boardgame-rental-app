using System.Threading;
using System.Threading.Tasks;
using Rental.Core.Common.Exceptions;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.CQRS;

namespace Rental.Core.Commands.Handlers
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
            var canBeRemoved =
                await _mediatorService.Send(new CheckIfClientHasOnlyCompletedRentalsQuery(command.Id),
                    cancellationToken);
            if (!canBeRemoved)
                throw new CustomValidationException(
                    $"Client with id {command.Id} can't be removed because of open rentals");
            await _mediatorService.Send(new RemoveAndSaveClientCommand(command.Id), cancellationToken);
        }
    }
}