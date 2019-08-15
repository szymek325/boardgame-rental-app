using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class RemoveBoardGameRequestHandler : AsyncRequestHandler<RemoveBoardGameRequest>
    {
        private readonly IMediatorService _mediatorService;

        public RemoveBoardGameRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(RemoveBoardGameRequest request, CancellationToken cancellationToken)
        {
            var canBeRemoved =
                await _mediatorService.SendQuery(new CheckIfBoardGameHasOnlyCompletedRentalsQuery(request.Id),
                    cancellationToken);
            if (!canBeRemoved)
                throw new ValidationException(
                    $"BoardGame with id {request.Id} can't be removed because of open rentals");

            await _mediatorService.SendCommand(new RemoveAndSaveBoardGameCommand(request.Id), cancellationToken);
        }
    }
}