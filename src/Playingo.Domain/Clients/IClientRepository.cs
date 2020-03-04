using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Playingo.Domain.Clients
{
    public interface IClientRepository
    {
        Task<IList<Client>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Client> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Client client, CancellationToken cancellationToken = default);
        Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task Update(Client client);
    }
}