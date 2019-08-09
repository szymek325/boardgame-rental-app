using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.Repositories
{
    [Obsolete("not supported, will be deleted")]
    public interface IClientsRepository
    {
        IEnumerable<Client> GetAll();
        Task<Client> GetAsync(int? id);
        Task AddAsync(Client entity);
        void Add(Client entity);
        void Remove(Client entity);
        void Update(Client entity);
    }
}