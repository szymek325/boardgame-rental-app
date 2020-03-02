using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.CommandHandlers
{
    internal class AddAndSaveRentalCommandHandler : ICommandHandler<AddAndSaveRentalCommand>
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
            var entity = _mapper.Map<Entities.Rental>(command.Rental);
            await _rentalContext.Rentals.AddAsync(entity, cancellationToken);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}