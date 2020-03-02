using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Domain;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.QueryHandlers
{
    internal class
        CheckIfBoardGameHasOnlyCompletedRentalsQueryHandler : IQueryHandler<CheckIfBoardGameHasOnlyCompletedRentalsQuery
            , bool>
    {
        private readonly RentalContext _rentalContext;

        public CheckIfBoardGameHasOnlyCompletedRentalsQueryHandler(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task<bool> Handle(CheckIfBoardGameHasOnlyCompletedRentalsQuery query,
            CancellationToken cancellationToken)
        {
            var allRentalsForBoardGameAreCompleted = await _rentalContext.Rentals
                .Where(x => x.BoardGameId == query.Id)
                .AllAsync(x => x.Status == Status.Completed, cancellationToken);
            return allRentalsForBoardGameAreCompleted;
        }
    }
}