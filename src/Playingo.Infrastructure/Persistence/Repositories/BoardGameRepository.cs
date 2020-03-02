using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Interfaces;
using Playingo.Domain.BoardGames;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.Repositories
{
    internal class BoardGameRepository : IBoardGameRepository
    {
        private readonly RentalContext _context;
        private readonly IMapper _mapper;

        public BoardGameRepository(RentalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<BoardGame>> GetAllAsync()
        {
            var entities = await _context.BoardGames.ToListAsync();
            var mappedEntities = _mapper.Map<IList<BoardGame>>(entities);
            return mappedEntities;
        }

        public async Task<BoardGame> GetByIdAsync(Guid id)
        {
            var entity = await _context.BoardGames.SingleOrDefaultAsync(x => x.Id == id);
            var result = _mapper.Map<BoardGame>(entity);
            return result;
        }

        public async Task AddAsync(BoardGame boardGame)
        {
            var entity = _mapper.Map<Entities.BoardGame>(boardGame);
            await _context.AddAsync(entity);
        }

        public async Task RemoveByIdAsync(Guid id)
        {
            var boardGame = await _context.BoardGames.SingleOrDefaultAsync(x => x.Id == id);
            _context.BoardGames.Remove(boardGame);
        }

        public Task UpdateAsync(BoardGame boardGame)
        {
            var entity = _mapper.Map<Entities.BoardGame>(boardGame);
            _context.BoardGames.Remove(entity);
            return Task.CompletedTask;
        }
    }
}