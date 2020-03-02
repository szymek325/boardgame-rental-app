using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly RentalContext _context;
        private readonly IMapper _mapper;

        public RentalRepository(RentalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> IsThereInProgressForBoardGameAsync(Guid id)
        {
            var areAllCompleted = await _context.Rentals
                .Where(x => x.BoardGameId == id)
                .AllAsync(x => x.Status == Status.Completed);
            return areAllCompleted;
        }

        public async Task<bool> IsThereInProgressForClient(Guid id)
        {
            var areAllCompleted = await _context.Rentals
                .Where(x => x.ClientId == id)
                .AllAsync(x => x.Status == Status.Completed);
            return areAllCompleted;
        }

        public async Task<IList<Rental>> GetAllForBoardGame(Guid id)
        {
            var entities = await _context.Rentals.Where(x => x.BoardGameId == id).ToListAsync();
            var mappedRentals = _mapper.Map<IList<Rental>>(entities);
            return mappedRentals;
        }

        public async Task<IList<Rental>> GetAllForClient(Guid id)
        {
            var entities = await _context.Rentals.Where(x => x.ClientId == id).ToListAsync();
            var mappedRentals = _mapper.Map<IList<Rental>>(entities);
            return mappedRentals;
        }

        public async Task<IList<Rental>> GetAll()
        {
            var entities = await _context.Rentals.ToListAsync();
            var mappedRentals = _mapper.Map<IList<Rental>>(entities);
            return mappedRentals;
        }

        public async Task<Rental> GetById(Guid id)
        {
            var entity = await _context.Rentals.SingleOrDefaultAsync(x => x.Id == id);
            var mappedEntity = _mapper.Map<Rental>(entity);
            return mappedEntity;
        }

        public async Task<RentalWithDetails> GetWithDetailsById(Guid id)
        {
            var entity = await _context.Rentals
                .Include(x => x.BoardGame)
                .Include(x => x.Client)
                .SingleOrDefaultAsync(x => x.Id == id);
            var mappedEntity = _mapper.Map<RentalWithDetails>(entity);
            return mappedEntity;
        }

        public async Task AddAsync(Rental rental)
        {
            var entity = _mapper.Map<Entities.Rental>(rental);
            await _context.Rentals.AddAsync(entity);
        }

        public Task Update(Rental rental)
        {
            var entity = _mapper.Map<Entities.Rental>(rental);
            _context.Rentals.Update(entity);
            return Task.CompletedTask;
        }
    }
}