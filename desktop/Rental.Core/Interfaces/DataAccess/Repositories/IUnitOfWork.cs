using System;
using System.Threading.Tasks;

namespace Rental.Core.Interfaces.DataAccess.Repositories
{
    [Obsolete("not supported, will be deleted")]
    public interface IUnitOfWork
    {
        IBoardGamesRepository BoardGamesRepository { get; }
        IClientsRepository ClientsRepository { get; }
        IGameRentalsRepository GameRentalsRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}