using System;
using System.Collections.Generic;
using System.Threading;
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
        private readonly IMapper _mapper;
        private readonly PlayingoContext _playingoContext;

        public ClientRepository(PlayingoContext playingoContext, IMapper mapper)
        {
            _playingoContext = playingoContext;
            _mapper = mapper;
        }

        public async Task<IList<Client>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _playingoContext.Clients.ToListAsync(cancellationToken);
            var mappedEntities = _mapper.Map<IList<Client>>(entities);
            return mappedEntities;
        }

        public async Task<Client> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _playingoContext.Clients.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            var result = _mapper.Map<Client>(entity);
            return result;
        }

        public async Task AddASync(Client client, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<Entities.Client>(client);
            await _playingoContext.AddAsync(entity, cancellationToken);
        }

        public async Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var client = await _playingoContext.Clients.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            _playingoContext.Clients.Remove(client);
        }

        public Task Update(Client client)
        {
            var entity = _mapper.Map<Entities.Client>(client);
            _playingoContext.Clients.Remove(entity);
            return Task.CompletedTask;
        }
    }
}