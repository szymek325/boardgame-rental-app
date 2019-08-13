using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Rental.Core.Interfaces.DataAccess.ClientRequests;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.Handlers.ClientHandlers
{
    internal class AddAndSaveClientNotificationHandler : INotificationHandler<AddAndSaveClientNotification>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public AddAndSaveClientNotificationHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(AddAndSaveClientNotification notification, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Client>(notification.Client);
            await _rentalContext.Clients.AddAsync(entity, cancellationToken);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}