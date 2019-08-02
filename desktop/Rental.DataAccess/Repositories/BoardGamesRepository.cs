using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Entities;
using Rental.Core.Interfaces.DataAccess;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Repositories
{
    internal class BoardGamesRepository : IBoardGamesRepository
    {
        private readonly RentalContext _rentalContext;

        public BoardGamesRepository(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _rentalContext.BoardGames;
        }

        public IEnumerable<BoardGame> GetAllAvailableForRental()
        {
            return _rentalContext.BoardGames
                .Where(x => x.GameRentals
                    .All(g => g.Status != Status.InProgress));
        }

        public async Task<BoardGame> GetAsync(int? id)
        {
            return await _rentalContext.BoardGames.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(BoardGame entity)
        {
            await _rentalContext.BoardGames.AddAsync(entity);
        }

        public void Remove(BoardGame entity)
        {
            _rentalContext.BoardGames.Remove(entity);
        }

        public void Update(BoardGame entity)
        {
            _rentalContext.BoardGames.Update(entity);
        }
    }
}