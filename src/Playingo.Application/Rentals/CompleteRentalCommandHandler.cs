using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Domain;

namespace Playingo.Application.Rentals
{
    internal class CompleteRentalCommandHandler : ICommandHandler<CompleteRentalCommand>
    {
        private readonly IMediatorService _mediatorService;

        public CompleteRentalCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task Handle(CompleteRentalCommand notification, CancellationToken cancellationToken)
        {
            var rental =
                await _mediatorService.Send(new GetRentalByIdQuery(notification.GameRentalId), cancellationToken);
            if (rental == null)
                throw new RentalNotFoundException(notification.GameRentalId);
            if (rental.Status != Status.InProgress)
                throw new RentalIsNotInProgressException(notification.GameRentalId);

            rental.Status = Status.Completed;
            rental.PaidMoney = notification.PaidMoney;

            await _mediatorService.Send(new UpdateAndSaveGameRentalCommand(rental), cancellationToken);
        }
    }
}