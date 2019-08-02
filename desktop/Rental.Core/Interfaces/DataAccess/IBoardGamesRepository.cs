using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rental.Core.Entities;

namespace Rental.Core.Interfaces.DataAccess
{
    public interface IBoardGamesRepository
    {
        IEnumerable<BoardGame> GetAll();
        IEnumerable<BoardGame> GetAllAvailableForRental();
        Task<BoardGame> GetAsync(int? id);
        Task AddAsync(BoardGame entity);
        void Remove(BoardGame entity);
        void Update(BoardGame entity);
    }
}