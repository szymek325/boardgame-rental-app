using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly RentalContext _context;

        private IBoardGameRepository _boardGameRepository;
        private IClientRepository _clientRepository;
        private IRentalRepository _rentalRepository;

        public UnitOfWork(RentalContext context)
        {
            _context = context;
        }

        public IBoardGameRepository BoardGameRepository
        {
            get { return _boardGameRepository ??= new BoardGameRepository(_context); }
        }

        public IClientRepository ClientRepository
        {
            get { return _clientRepository ??= new ClientRepository(_context); }
        }

        public IRentalRepository RentalRepository
        {
            get { return _rentalRepository ??= new RentalRepository(_context); }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}