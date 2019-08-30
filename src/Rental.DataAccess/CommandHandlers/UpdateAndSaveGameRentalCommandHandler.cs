using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.CQS;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.CommandHandlers
{
    internal class UpdateAndSaveGameRentalCommandHandler : ICommandHandler<UpdateAndSaveGameRentalCommand>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public UpdateAndSaveGameRentalCommandHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(UpdateAndSaveGameRentalCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Entities.Rental>(command.Rental);
            _rentalContext.Rentals.Update(entity);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}