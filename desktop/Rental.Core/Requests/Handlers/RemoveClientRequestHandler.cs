using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Interfaces.DataAccess.ClientRequests;

namespace Rental.Core.Requests.Handlers
{
    internal class RemoveClientRequestHandler : IRequestHandler<RemoveClientRequest, string>
    {
        private readonly IMediator _mediator;

        public RemoveClientRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> Handle(RemoveClientRequest request, CancellationToken cancellationToken)
        {
            var canBeRemoved =
                await _mediator.Send(new CheckIfBoardGameCanBeRemovedRequest(request.Id), cancellationToken);
            if (!canBeRemoved) return $"BoardGame with id {request.Id} can't be removed because of open rentals";

            await _mediator.Publish(new RemoveAndSaveClientNotification(request.Id), cancellationToken);
            return $"BoardGame with id {request.Id} was removed successfully";
        }
    }
}