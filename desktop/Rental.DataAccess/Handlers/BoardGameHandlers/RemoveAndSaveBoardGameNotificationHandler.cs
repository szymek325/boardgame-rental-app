using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.BoardGameHandlers
{
    internal class RemoveAndSaveBoardGameNotificationHandler : INotificationHandler<RemoveAndSaveBoardGameNotification>
    {
        private readonly RentalContext _rentalContext;

        public RemoveAndSaveBoardGameNotificationHandler(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task Handle(RemoveAndSaveBoardGameNotification notification, CancellationToken cancellationToken)
        {
            var boardGame =
                await _rentalContext.BoardGames.SingleOrDefaultAsync(x => x.Id == notification.Id, cancellationToken);
            _rentalContext.BoardGames.Remove(boardGame);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}