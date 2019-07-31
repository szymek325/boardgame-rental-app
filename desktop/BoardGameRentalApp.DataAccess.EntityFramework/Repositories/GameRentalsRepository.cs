using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace BoardGameRentalApp.DataAccess.EntityFramework.Repositories
{
    internal class GameRentalsRepository : IGameRentalsRepository
    {
        private readonly BoardGamesShopContext _boardGamesShopContext;

        public GameRentalsRepository(BoardGamesShopContext boardGamesShopContext)
        {
            _boardGamesShopContext = boardGamesShopContext;
        }

        public IQueryable<GameRental> GetAll()
        {
            return _boardGamesShopContext.GameRentals;
        }

        public IEnumerable<GameRental> GetForClient(int? clientId)
        {
            return GetAll()
                .Include(x => x.BoardGame)
                .Where(x => x.ClientId == clientId);
        }

        public IEnumerable<GameRental> GetForBoardGame(int? boardGameId)
        {
            return GetAll()
                .Include(x => x.Client)
                .Where(x => x.ClientId == boardGameId);
        }

        public GameRental GetWithDetails(int? id)
        {
            return GetAll()
                .Include(x => x.BoardGame)
                .Include(x => x.Client)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task AddAsync(GameRental entity)
        {
            await _boardGamesShopContext.GameRentals.AddAsync(entity);
        }

        public void Update(GameRental entity)
        {
            _boardGamesShopContext.GameRentals.Update(entity);
        }
    }
}