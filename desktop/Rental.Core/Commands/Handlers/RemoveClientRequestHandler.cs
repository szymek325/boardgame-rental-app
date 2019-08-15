using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class RemoveClientRequestHandler : AsyncRequestHandler<RemoveClientRequest>
    {
        private readonly IMediator _mediator;

        public RemoveClientRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override async Task Handle(RemoveClientRequest request, CancellationToken cancellationToken)
        {
            var canBeRemoved =
                await _mediator.Send(new CheckIfBoardGameHasOnlyCompletedRentalsQuery(request.Id), cancellationToken);
            if (!canBeRemoved)
                throw new ValidationException($"Client with id {request.Id} can't be removed because of open rentals");

            await _mediator.Publish(new RemoveAndSaveClientCommand(request.Id), cancellationToken);
        }
    }
}