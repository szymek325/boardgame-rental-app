using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Playingo.Domain.Clients;

namespace Playingo.Application.Common.Interfaces
{
    public interface IClientRepository
    {
        Task<IList<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(Guid id);
        Task AddASync(Client client);
        Task RemoveByIdAsync(Guid id);
        Task UpdateAsync(Client client);
    }
}