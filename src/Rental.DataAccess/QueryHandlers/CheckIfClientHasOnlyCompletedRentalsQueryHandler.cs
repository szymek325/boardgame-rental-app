using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Playingo.Domain;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.CQS;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.QueryHandlers
{
    internal class
        CheckIfClientHasOnlyCompletedRentalsQueryHandler : IQueryHandler<CheckIfClientHasOnlyCompletedRentalsQuery, bool
        >
    {
        private readonly RentalContext _rentalContext;

        public CheckIfClientHasOnlyCompletedRentalsQueryHandler(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task<bool> Handle(CheckIfClientHasOnlyCompletedRentalsQuery query,
            CancellationToken cancellationToken)
        {
            var allRentalsForClientAreCompleted = await _rentalContext.Rentals
                .Where(x => x.ClientId == query.Id)
                .AllAsync(x => x.Status == Status.Completed, cancellationToken);
            return allRentalsForClientAreCompleted;
        }
    }
}