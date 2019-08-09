using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.Repositories
{
    [Obsolete("not supported, will be deleted")]
    public interface IBoardGamesRepository
    {
        IEnumerable<BoardGame> GetAll();
        IEnumerable<BoardGame> GetAllAvailableForRental();
        Task<BoardGame> GetAsync(int? id);
        Task AddAsync(BoardGame model);
        void Remove(BoardGame model);
        void Update(BoardGame model);
    }
}