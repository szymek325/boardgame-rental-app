using System.Threading;
using System.Threading.Tasks;
using Rental.Core.Common.Exceptions;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.CQS;

namespace Rental.Core.Commands.Handlers
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