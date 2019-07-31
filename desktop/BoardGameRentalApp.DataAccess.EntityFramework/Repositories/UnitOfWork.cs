using System.Threading.Tasks;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;

namespace BoardGameRentalApp.DataAccess.EntityFramework.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly BoardGamesShopContext _boardGamesShopContext;
        private IBoardGamesRepository _boardGamesRepository;
        private IClientsRepository _clientsRepository;
        private IGameRentalsRepository _gameRentalsRepository;

        public UnitOfWork(BoardGamesShopContext boardGamesShopContext)
        {
            _boardGamesShopContext = boardGamesShopContext;
        }

        public IBoardGamesRepository BoardGamesRepository
        {
            get { return _boardGamesRepository = _boardGamesRepository ?? new BoardGamesRepository(_boardGamesShopContext); }
        }

        public IClientsRepository ClientsRepository
        {
            get { return _clientsRepository = _clientsRepository ?? new ClientsRepository(_boardGamesShopContext); }
        }

        public IGameRentalsRepository GameRentalsRepository
        {
            get { return _gameRentalsRepository = _gameRentalsRepository ?? new GameRentalsRepository(_boardGamesShopContext); }
        }

        public void SaveChanges()
        {
            _boardGamesShopContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _boardGamesShopContext.SaveChangesAsync();
        }
    }
}