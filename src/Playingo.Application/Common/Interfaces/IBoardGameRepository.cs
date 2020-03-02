using System.Threading.Tasks;
using Playingo.Domain.BoardGames;

namespace Playingo.Application.Common.Interfaces
{
    public interface IBoardGameRepository
    {
        Task AddAsync(BoardGame boardGame);
    }
}