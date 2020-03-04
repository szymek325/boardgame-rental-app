using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Playingo.Application.Common.Interfaces;
using Playingo.Domain.BoardGames;
using Playingo.Domain.Clients;
using Playingo.Domain.Rentals;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly PlayingoContext _playingoContext;

        private IBoardGameRepository _boardGameRepository;
        private IClientRepository _clientRepository;
        private IRentalRepository _rentalRepository;

        public UnitOfWork(PlayingoContext playingoContext, IMapper mapper)
        {
            _playingoContext = playingoContext;
            _mapper = mapper;
        }

        public IBoardGameRepository BoardGameRepository
        {
            get { return _boardGameRepository ??= new BoardGameRepository(_playingoContext, _mapper); }
        }

        public IClientRepository ClientRepository
        {
            get { return _clientRepository ??= new ClientRepository(_playingoContext, _mapper); }
        }

        public IRentalRepository RentalRepository
        {
            get { return _rentalRepository ??= new RentalRepository(_playingoContext, _mapper); }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _playingoContext.SaveChangesAsync(cancellationToken);
        }
    }
}