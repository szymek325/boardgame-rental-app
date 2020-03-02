using System;
using System.Collections.Generic;
using System.Threading;
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
        private readonly IMapper _mapper;
        private readonly PlayingoContext _playingoContext;

        public BoardGameRepository(PlayingoContext playingoContext, IMapper mapper)
        {
            _playingoContext = playingoContext;
            _mapper = mapper;
        }

        public async Task<IList<BoardGame>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _playingoContext.BoardGames.ToListAsync(cancellationToken);
            var mappedEntities = _mapper.Map<IList<BoardGame>>(entities);
            return mappedEntities;
        }

        public async Task<BoardGame> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _playingoContext.BoardGames.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            var result = _mapper.Map<BoardGame>(entity);
            return result;
        }

        public async Task AddAsync(BoardGame boardGame, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<Entities.BoardGame>(boardGame);
            await _playingoContext.AddAsync(entity, cancellationToken);
        }

        public async Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var boardGame = await _playingoContext.BoardGames.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            _playingoContext.BoardGames.Remove(boardGame);
        }

        public Task Update(BoardGame boardGame)
        {
            var entity = _mapper.Map<Entities.BoardGame>(boardGame);
            _playingoContext.BoardGames.Update(entity);
            return Task.CompletedTask;
        }
    }
}