using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.ClientRequests;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.ClientHandlers
{
    internal class RemoveAndSaveClientNotificationHandler : INotificationHandler<RemoveAndSaveClientNotification>
    {
        private readonly RentalContext _rentalContext;

        public RemoveAndSaveClientNotificationHandler(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task Handle(RemoveAndSaveClientNotification notification, CancellationToken cancellationToken)
        {
            var client = await _rentalContext.Clients.SingleOrDefaultAsync(x => x.Id == notification.Id, cancellationToken);
            _rentalContext.Clients.Remove(client);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}