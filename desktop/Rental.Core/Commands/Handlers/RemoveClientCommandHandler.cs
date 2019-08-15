using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Common;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class RemoveClientCommandHandler : AsyncRequestHandler<RemoveClientCommand>
    {
        private readonly IMediatorService _mediatorService;

        public RemoveClientCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(RemoveClientCommand command, CancellationToken cancellationToken)
        {
            var canBeRemoved =
                await _mediatorService.SendQuery(new CheckIfBoardGameHasOnlyCompletedRentalsQuery(command.Id),
                    cancellationToken);
            if (!canBeRemoved)
                throw new ValidationException($"Client with id {command.Id} can't be removed because of open rentals");

            await _mediatorService.SendCommand(new RemoveAndSaveClientCommand(command.Id), cancellationToken);
        }
    }
}