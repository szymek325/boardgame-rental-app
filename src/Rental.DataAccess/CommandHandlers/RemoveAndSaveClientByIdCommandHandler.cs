using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.CommandHandlers
{
    internal class RemoveAndSaveClientByIdCommandHandler : ICommandHandler<RemoveAndSaveClientByIdCommand>
    {
        private readonly RentalContext _rentalContext;

        public RemoveAndSaveClientByIdCommandHandler(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task Handle(RemoveAndSaveClientByIdCommand byIdCommand, CancellationToken cancellationToken)
        {
            var client =
                await _rentalContext.Clients.SingleOrDefaultAsync(x => x.Id == byIdCommand.Id, cancellationToken);
            _rentalContext.Clients.Remove(client);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}