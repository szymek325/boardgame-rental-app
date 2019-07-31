using System.Collections.Generic;
using System.Threading.Tasks;
using Rental.Core.Entities;

namespace Rental.Core.Interfaces.DataAccess
{
    public interface IClientsRepository
    {
        IEnumerable<Client> GetAll();
        Client Get(int? id);
        Task AddAsync(Client entity);
        void Remove(Client entity);
        void Update(Client entity);
    }
}