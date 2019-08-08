using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Repositories
{
    internal class ClientsRepository : IClientsRepository
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public ClientsRepository(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public IEnumerable<Client> GetAll()
        {
            var entities = _rentalContext.Clients;
            var result = _mapper.Map<IEnumerable<Client>>(entities);
            return result;
        }

        public async Task<Client> GetAsync(int? id)
        {
            var entity = await _rentalContext.Clients.SingleOrDefaultAsync(x => x.Id == id);
            var result = _mapper.Map<Client>(entity);
            return result;
        }

        public async Task AddAsync(Client model)
        {
            var entity = _mapper.Map<Entities.Client>(model);
            await _rentalContext.Clients.AddAsync(entity);
        }

        public void Remove(Client model)
        {
            var entity = _mapper.Map<Entities.Client>(model);
            _rentalContext.Clients.Remove(entity);
        }

        public void Update(Client model)
        {
            var entity = _mapper.Map<Entities.Client>(model);
            _rentalContext.Clients.Update(entity);
        }

        public void Add(Client model)
        {
            var entity = _mapper.Map<Entities.Client>(model);
            _rentalContext.Clients.Add(entity);
        }
    }
}