using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.CommandHandlers
{
    internal class AddAndSaveRentalCommandHandler : INotificationHandler<AddAndSaveRentalCommand>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public AddAndSaveRentalCommandHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(AddAndSaveRentalCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<GameRental>(command.GameRental);
            await _rentalContext.GameRentals.AddAsync(entity, cancellationToken);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}