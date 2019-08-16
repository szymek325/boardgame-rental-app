using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.CQRS;

namespace Rental.Core.Commands.Handlers
{
    internal class RemoveBoardGameCommandHandler : ICommandHandler<RemoveBoardGameCommand>
    {
        private readonly IMediatorService _mediatorService;

        public RemoveBoardGameCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task Handle(RemoveBoardGameCommand command, CancellationToken cancellationToken)
        {
            var canBeRemoved =
                await _mediatorService.Send(new CheckIfBoardGameHasOnlyCompletedRentalsQuery(command.Id),
                    cancellationToken);
            if (!canBeRemoved)
                throw new ValidationException(
                    $"BoardGame with id {command.Id} can't be removed because of open rentals");
            await _mediatorService.Send(new RemoveAndSaveBoardGameCommand(command.Id), cancellationToken);
        }
    }
}