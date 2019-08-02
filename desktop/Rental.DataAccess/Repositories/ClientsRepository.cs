using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Entities;
using Rental.Core.Interfaces.DataAccess;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Repositories
{
    internal class ClientsRepository : IClientsRepository
    {
        private readonly RentalContext _rentalContext;

        public ClientsRepository(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public IEnumerable<Client> GetAll()
        {
            return _rentalContext.Clients.ToList();
        }

        public async Task<Client> GetAsync(int? id)
        {
            return await _rentalContext.Clients.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Client entity)
        {
            await _rentalContext.Clients.AddAsync(entity);
        }

        public void Remove(Client entity)
        {
            _rentalContext.Clients.Remove(entity);
        }

        public void Update(Client entity)
        {
            _rentalContext.Clients.Update(entity);
        }
    }
}