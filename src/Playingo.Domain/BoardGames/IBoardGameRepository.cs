using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Playingo.Domain.BoardGames
{
    public interface IBoardGameRepository
    {
        Task<IList<BoardGame>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<BoardGame> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(BoardGame boardGame, CancellationToken cancellationToken = default);
        Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task Update(BoardGame boardGame);
    }
}