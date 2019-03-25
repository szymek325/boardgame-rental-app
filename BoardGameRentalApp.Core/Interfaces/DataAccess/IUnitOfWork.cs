﻿using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Interfaces.DataAccess
{
    public interface IUnitOfWork
    {
        IBoardGamesRepository BoardGamesRepository { get; }
        IClientsRepository ClientsRepository { get; }
        IGameRentalsRepository GameRentalsRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}