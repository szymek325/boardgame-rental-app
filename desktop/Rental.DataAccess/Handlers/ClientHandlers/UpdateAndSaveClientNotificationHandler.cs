using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Rental.Core.Interfaces.DataAccess.ClientRequests;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.Handlers.ClientHandlers
{
    internal class UpdateAndSaveClientNotificationHandler : INotificationHandler<UpdateAndSaveClientNotification>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public UpdateAndSaveClientNotificationHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(UpdateAndSaveClientNotification notification, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Client>(notification.Client);
            _rentalContext.Clients.Update(entity);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}