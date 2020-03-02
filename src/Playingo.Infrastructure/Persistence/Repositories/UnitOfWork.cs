using System.Threading.Tasks;
using AutoMapper;
using Playingo.Application.Common.Interfaces;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly RentalContext _context;
        private readonly IMapper _mapper;

        private IBoardGameRepository _boardGameRepository;
        private IClientRepository _clientRepository;
        private IRentalRepository _rentalRepository;

        public UnitOfWork(RentalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IBoardGameRepository BoardGameRepository
        {
            get { return _boardGameRepository ??= new BoardGameRepository(_context, _mapper); }
        }

        public IClientRepository ClientRepository
        {
            get { return _clientRepository ??= new ClientRepository(_context, _mapper); }
        }

        public IRentalRepository RentalRepository
        {
            get { return _rentalRepository ??= new RentalRepository(_context, _mapper); }
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