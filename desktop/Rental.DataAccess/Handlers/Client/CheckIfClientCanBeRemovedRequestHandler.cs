using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess;
using Rental.Core.Interfaces.DataAccess.Client;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.Client
{
    internal class CheckIfClientCanBeRemovedRequestHandler : IRequestHandler<CheckIfClientCanBeRemovedRequest, bool>
    {
        private readonly RentalContext _rentalContext;

        public CheckIfClientCanBeRemovedRequestHandler(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task<bool> Handle(CheckIfClientCanBeRemovedRequest request, CancellationToken cancellationToken)
        {
            var canBeRemoved = await _rentalContext.GameRentals.Where(x => x.ClientId == request.Id)
                .AllAsync(x => x.Status == Status.Completed, cancellationToken);
            return canBeRemoved;
        }
    }
}