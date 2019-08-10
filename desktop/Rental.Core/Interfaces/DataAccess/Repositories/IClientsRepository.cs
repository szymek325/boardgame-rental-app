using Rental.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rental.Core.Interfaces.DataAccess.Repositories
{
    [Obsolete("not supported, will be deleted")]
    public interface IClientsRepository
    {
        IEnumerable<Client> GetAll();
        Task<Client> GetAsync(Guid? id);
        Task AddAsync(Client entity);
        void Add(Client entity);
        void Remove(Client entity);
        void Update(Client entity);
    }
}