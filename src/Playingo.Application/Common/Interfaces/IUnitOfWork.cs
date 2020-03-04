using System.Threading;
using System.Threading.Tasks;
using Playingo.Domain.BoardGames;
using Playingo.Domain.Clients;
using Playingo.Domain.Rentals;

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