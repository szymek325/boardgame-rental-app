using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Infrastructure.Persistence.Context;
using Playingo.Infrastructure.Persistence.Entities;

namespace Playingo.Infrastructure.Persistence.CommandHandlers
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