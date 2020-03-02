using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Playingo.Domain.BoardGames;

namespace Playingo.Application.Common.Interfaces
{
    public interface IBoardGameRepository
    {
        Task<IList<BoardGame>> GetAllAsync();
        Task<BoardGame> GetByIdAsync(Guid id);
        Task AddAsync(BoardGame boardGame);
        Task RemoveByIdAsync(Guid id);
        Task UpdateAsync(BoardGame boardGame);
    }
}