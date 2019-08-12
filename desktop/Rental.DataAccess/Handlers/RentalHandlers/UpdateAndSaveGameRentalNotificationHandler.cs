using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Rental.Core.Interfaces.DataAccess.GameRentalRequests;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.Handlers.RentalHandlers
{
    internal class UpdateAndSaveGameRentalNotificationHandler : INotificationHandler<UpdateAndSaveGameRentalNotification>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public UpdateAndSaveGameRentalNotificationHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(UpdateAndSaveGameRentalNotification notification, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<GameRental>(notification.GameRental);
            _rentalContext.GameRentals.Update(entity);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}