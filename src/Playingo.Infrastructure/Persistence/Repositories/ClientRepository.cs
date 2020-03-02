using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Interfaces;
using Playingo.Domain.Clients;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly RentalContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(RentalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<Client>> GetAllAsync()
        {
            var entities = await _context.Clients.ToListAsync();
            var mappedEntities = _mapper.Map<IList<Client>>(entities);
            return mappedEntities;
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            var entity = await _context.Clients.SingleOrDefaultAsync(x => x.Id == id);
            var result = _mapper.Map<Client>(entity);
            return result;
        }

        public async Task AddASync(Client client)
        {
            var entity = _mapper.Map<Entities.Client>(client);
            await _context.AddAsync(entity);
        }

        public async Task RemoveByIdAsync(Guid id)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(x => x.Id == id);
            _context.Clients.Remove(client);
        }

        public Task UpdateAsync(Client client)
        {
            var entity = _mapper.Map<Entities.Client>(client);
            _context.Clients.Remove(entity);
            return Task.CompletedTask;
        }
    }
}