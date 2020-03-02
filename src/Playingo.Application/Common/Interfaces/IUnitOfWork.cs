using System.Threading.Tasks;

namespace Playingo.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IBoardGameRepository BoardGameRepository { get; }
        IClientRepository ClientRepository { get; }
        IRentalRepository RentalRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}