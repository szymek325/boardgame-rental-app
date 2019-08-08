using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess
{
    public interface IGameRentalsRepository
    {
        IEnumerable<GameRental> GetAll();
        Task<GameRental> GetAsync(Guid? id);
        Task AddAsync(GameRental model);
        void Update(GameRental model);
    }
}