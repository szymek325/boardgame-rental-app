using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.BoardGameHandlers
{
    internal class
        CheckIfBoardGameCanBeRemovedRequestHandler : IRequestHandler<CheckIfBoardGameCanBeRemovedRequest, bool>
    {
        private readonly RentalContext _rentalContext;

        public CheckIfBoardGameCanBeRemovedRequestHandler(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task<bool> Handle(CheckIfBoardGameCanBeRemovedRequest request, CancellationToken cancellationToken)
        {
            var canBeRemoved = await _rentalContext.GameRentals.Where(x => x.BoardGameId == request.Id)
                .AllAsync(x => x.Status == Status.Completed, cancellationToken);
            return canBeRemoved;
        }
    }
}