using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess
{
    public interface IBoardGamesRepository
    {
        IEnumerable<BoardGame> GetAll();
        IEnumerable<BoardGame> GetAllAvailableForRental();
        Task<BoardGame> GetAsync(Guid? id);
        Task AddAsync(BoardGame model);
        void Remove(BoardGame model);
        void Update(BoardGame model);
    }
}