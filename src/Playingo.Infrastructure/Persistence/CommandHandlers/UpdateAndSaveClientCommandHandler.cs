using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Infrastructure.Persistence.Context;
using Playingo.Infrastructure.Persistence.Entities;

namespace Playingo.Infrastructure.Persistence.CommandHandlers
{
    internal class UpdateAndSaveClientCommandHandler : ICommandHandler<UpdateAndSaveClientCommand>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public UpdateAndSaveClientCommandHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(UpdateAndSaveClientCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Client>(command.Client);
            _rentalContext.Clients.Update(entity);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}