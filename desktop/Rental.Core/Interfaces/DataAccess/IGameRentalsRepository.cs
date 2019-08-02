using System.Collections.Generic;
using System.Threading.Tasks;
using Rental.Core.Entities;

namespace Rental.Core.Interfaces.DataAccess
{
    public interface IGameRentalsRepository
    {
        IEnumerable<GameRental> GetAll();
        Task<GameRental> GetAsync(int? id);
        Task AddAsync(GameRental entity);
        void Update(GameRental entity);
    }
}