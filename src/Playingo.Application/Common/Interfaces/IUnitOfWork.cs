using System.Threading;
using System.Threading.Tasks;

namespace Playingo.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IBoardGameRepository BoardGameRepository { get; }
        IClientRepository ClientRepository { get; }
        IRentalRepository RentalRepository { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}