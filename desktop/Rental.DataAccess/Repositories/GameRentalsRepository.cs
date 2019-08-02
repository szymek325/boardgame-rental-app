using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Entities;
using Rental.Core.Interfaces.DataAccess;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Repositories
{
    internal class GameRentalsRepository : IGameRentalsRepository
    {
        private readonly RentalContext _rentalContext;

        public GameRentalsRepository(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public IEnumerable<GameRental> GetAll()
        {
            return _rentalContext.GameRentals;
        }

        public async Task<GameRental> GetAsync(int? id)
        {
            return await _rentalContext.GameRentals
                .Include(x => x.BoardGame)
                .Include(x => x.Client)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(GameRental entity)
        {
            await _rentalContext.GameRentals.AddAsync(entity);
        }

        public void Update(GameRental entity)
        {
            _rentalContext.GameRentals.Update(entity);
        }
    }
}