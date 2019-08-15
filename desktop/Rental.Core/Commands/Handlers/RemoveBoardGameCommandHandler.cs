using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Common;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class RemoveBoardGameCommandHandler : AsyncRequestHandler<RemoveBoardGameCommand>
    {
        private readonly IMediatorService _mediatorService;

        public RemoveBoardGameCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(RemoveBoardGameCommand command, CancellationToken cancellationToken)
        {
            var canBeRemoved =
                await _mediatorService.SendQuery(new CheckIfBoardGameHasOnlyCompletedRentalsQuery(command.Id),
                    cancellationToken);
            if (!canBeRemoved)
                throw new ValidationException(
                    $"BoardGame with id {command.Id} can't be removed because of open rentals");

            await _mediatorService.SendCommand(new RemoveAndSaveBoardGameCommand(command.Id), cancellationToken);
        }
    }
}