using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Common;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.CommandHandlers
{
    internal class RemoveAndSaveClientCommandHandler : ICommandHandler<RemoveAndSaveClientCommand>
    {
        private readonly RentalContext _rentalContext;

        public RemoveAndSaveClientCommandHandler(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task Handle(RemoveAndSaveClientCommand command, CancellationToken cancellationToken)
        {
            var client =
                await _rentalContext.Clients.SingleOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
            _rentalContext.Clients.Remove(client);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}