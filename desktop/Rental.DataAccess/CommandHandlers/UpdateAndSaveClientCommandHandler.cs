using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.CommandHandlers
{
    internal class UpdateAndSaveClientCommandHandler : INotificationHandler<UpdateAndSaveClientCommand>
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