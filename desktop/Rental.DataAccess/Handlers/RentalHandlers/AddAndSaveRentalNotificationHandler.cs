using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Rental.Core.Interfaces.DataAccess.GameRentalRequests;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.Handlers.RentalHandlers
{
    internal class AddAndSaveRentalNotificationHandler : INotificationHandler<AddAndSaveRentalNotification>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public AddAndSaveRentalNotificationHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(AddAndSaveRentalNotification notification, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<GameRental>(notification.GameRental);
            await _rentalContext.GameRentals.AddAsync(entity, cancellationToken);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}