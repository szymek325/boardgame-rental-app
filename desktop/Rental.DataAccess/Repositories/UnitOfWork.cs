using System.Threading.Tasks;
using Rental.Core.Interfaces.DataAccess;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly RentalContext _rentalContext;
        private IBoardGamesRepository _boardGamesRepository;
        private IClientsRepository _clientsRepository;
        private IGameRentalsRepository _gameRentalsRepository;

        public UnitOfWork(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public IBoardGamesRepository BoardGamesRepository
        {
            get { return _boardGamesRepository ??= new BoardGamesRepository(_rentalContext); }
        }

        public IClientsRepository ClientsRepository
        {
            get { return _clientsRepository ??= new ClientsRepository(_rentalContext); }
        }

        public IGameRentalsRepository GameRentalsRepository
        {
            get { return _gameRentalsRepository ??= new GameRentalsRepository(_rentalContext); }
        }

        public void SaveChanges()
        {
            _rentalContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _rentalContext.SaveChangesAsync();
        }
    }
}