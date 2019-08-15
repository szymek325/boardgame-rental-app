using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.CommandHandlers
{
    internal class RemoveAndSaveBoardGameCommandHandler : INotificationHandler<RemoveAndSaveBoardGameCommand>
    {
        private readonly RentalContext _rentalContext;

        public RemoveAndSaveBoardGameCommandHandler(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task Handle(RemoveAndSaveBoardGameCommand command, CancellationToken cancellationToken)
        {
            var boardGame =
                await _rentalContext.BoardGames.SingleOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
            _rentalContext.BoardGames.Remove(boardGame);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}