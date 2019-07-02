﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;

namespace BoardGameRentalApp.Core.Interfaces.DataAccess
{
    public interface IGameRentalsRepository
    {
        IQueryable<GameRental> GetAll();
        IEnumerable<GameRental> GetForClient(int? clientId);
        IEnumerable<GameRental> GetForBoardGame(int? boardGameId);
        GameRental GetWithDetails(int? id);
        Task AddAsync(GameRental entity);
        void Update(GameRental entity);
    }
}