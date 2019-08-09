using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.Repositories
{
    [Obsolete("not supported, will be deleted")]
    public interface IGameRentalsRepository
    {
        IEnumerable<GameRental> GetAll();
        Task<GameRental> GetAsync(int? id);
        Task AddAsync(GameRental model);
        void Update(GameRental model);
    }
}