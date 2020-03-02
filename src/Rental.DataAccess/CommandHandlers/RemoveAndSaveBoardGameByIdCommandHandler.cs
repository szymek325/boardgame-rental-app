using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.CommandHandlers
{
    internal class RemoveAndSaveBoardGameByIdCommandHandler : ICommandHandler<RemoveAndSaveBoardGameByIdCommand>
    {
        private readonly RentalContext _rentalContext;

        public RemoveAndSaveBoardGameByIdCommandHandler(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task Handle(RemoveAndSaveBoardGameByIdCommand byIdCommand, CancellationToken cancellationToken)
        {
            var boardGame =
                await _rentalContext.BoardGames.SingleOrDefaultAsync(x => x.Id == byIdCommand.Id, cancellationToken);
            _rentalContext.BoardGames.Remove(boardGame);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}