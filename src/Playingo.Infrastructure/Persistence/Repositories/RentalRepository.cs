using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Domain.Rentals;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.Repositories
{
    internal class RentalRepository:IRentalRepository
    {
        private readonly RentalContext _context;

        public RentalRepository(RentalContext context)
        {
            _context = context;
        }

        public Task AddAsync(Rental rental)
        {
            throw new System.NotImplementedException();
        }
    }
}