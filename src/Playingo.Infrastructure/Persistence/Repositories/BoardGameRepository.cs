using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Domain.BoardGames;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.Repositories
{
    internal class BoardGameRepository:IBoardGameRepository
    {
        private readonly RentalContext _context;
        public BoardGameRepository(RentalContext context)
        {
            _context = context;
        }

        public Task AddAsync(BoardGame boardGame)
        {
            throw new System.NotImplementedException();
        }
    }
}