using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.CommandHandlers
{
    internal class RemoveAndSaveClientCommandHandler : ICommandHandler<RemoveAndSaveClientCommand>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public RemoveAndSaveClientCommandHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(RemoveAndSaveClientCommand command, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(command.Client);
            _rentalContext.Clients.Remove(client);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}