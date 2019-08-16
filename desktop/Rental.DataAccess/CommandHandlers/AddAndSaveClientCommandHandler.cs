using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.CQRS;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.CommandHandlers
{
    internal class AddAndSaveClientCommandHandler : ICommandHandler<AddAndSaveClientCommand>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public AddAndSaveClientCommandHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(AddAndSaveClientCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Client>(command.Client);
            await _rentalContext.Clients.AddAsync(entity, cancellationToken);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}