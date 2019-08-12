using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.Handlers.BoardGameHandlers
{
    internal class AddAndSaveBoardGameNotificationHandler : INotificationHandler<AddAndSaveBoardGameNotification>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public AddAndSaveBoardGameNotificationHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(AddAndSaveBoardGameNotification notification, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BoardGame>(notification.BoardGame);
            await _rentalContext.BoardGames.AddAsync(entity, cancellationToken);
        }
    }
}