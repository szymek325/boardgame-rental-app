using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Interfaces;
using Playingo.Domain;
using Playingo.Domain.Rentals;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.Repositories
{
    internal class RentalRepository : IRentalRepository
    {
        private readonly IMapper _mapper;
        private readonly PlayingoContext _playingoContext;

        public RentalRepository(PlayingoContext playingoContext, IMapper mapper)
        {
            _playingoContext = playingoContext;
            _mapper = mapper;
        }

        public async Task<bool> AreAllCompletedForBoardGameAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var areAllCompleted = await _playingoContext.Rentals
                .Where(x => x.BoardGameId == id)
                .AllAsync(x => x.Status == Status.Completed, cancellationToken);
            return areAllCompleted;
        }

        public async Task<bool> AreAllCompletedForClientAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var areAllCompleted = await _playingoContext.Rentals
                .Where(x => x.ClientId == id)
                .AllAsync(x => x.Status == Status.Completed, cancellationToken);
            return areAllCompleted;
        }

        public async Task<IList<Rental>> GetAllForBoardGameAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entities = await _playingoContext.Rentals.Where(x => x.BoardGameId == id)
                .ToListAsync(cancellationToken);
            var mappedRentals = _mapper.Map<IList<Rental>>(entities);
            return mappedRentals;
        }

        public async Task<IList<Rental>> GetAllForClientAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entities = await _playingoContext.Rentals.Where(x => x.ClientId == id).ToListAsync(cancellationToken);
            var mappedRentals = _mapper.Map<IList<Rental>>(entities);
            return mappedRentals;
        }

        public async Task<IList<Rental>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _playingoContext.Rentals.ToListAsync(cancellationToken);
            var mappedRentals = _mapper.Map<IList<Rental>>(entities);
            return mappedRentals;
        }

        public async Task<Rental> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _playingoContext.Rentals.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            var mappedEntity = _mapper.Map<Rental>(entity);
            return mappedEntity;
        }

        public async Task<RentalWithDetails> GetWithDetailsByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var entity = await _playingoContext.Rentals
                .Include(x => x.BoardGame)
                .Include(x => x.Client)
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            var mappedEntity = _mapper.Map<RentalWithDetails>(entity);
            return mappedEntity;
        }

        public async Task AddAsync(Rental rental, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<Entities.Rental>(rental);
            await _playingoContext.Rentals.AddAsync(entity, cancellationToken);
        }

        public Task Update(Rental rental)
        {
            var entity = _mapper.Map<Entities.Rental>(rental);
            _playingoContext.Rentals.Update(entity);
            return Task.CompletedTask;
        }
    }
}