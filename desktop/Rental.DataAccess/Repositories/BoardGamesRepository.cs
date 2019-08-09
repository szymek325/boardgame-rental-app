using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Repositories;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Repositories
{
    internal class BoardGamesRepository : IBoardGamesRepository
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public BoardGamesRepository(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public IEnumerable<BoardGame> GetAll()
        {
            var entities = _rentalContext.BoardGames;
            var result = _mapper.Map<IEnumerable<BoardGame>>(entities);
            return result;
        }

        public IEnumerable<BoardGame> GetAllAvailableForRental()
        {
            var entities = _rentalContext.BoardGames.Where(x => x.GameRentals.All(g => g.Status != Status.InProgress));
            var result = _mapper.Map<IEnumerable<BoardGame>>(entities);
            return result;
        }

        public async Task<BoardGame> GetAsync(int? id)
        {
            var entity = await _rentalContext.BoardGames.SingleOrDefaultAsync(x => x.Id == id);
            var result = _mapper.Map<BoardGame>(entity);
            return result;
        }

        public async Task AddAsync(BoardGame model)
        {
            var entity = _mapper.Map<Entities.BoardGame>(model);
            await _rentalContext.BoardGames.AddAsync(entity);
        }

        public void Remove(BoardGame model)
        {
            var entity = _mapper.Map<Entities.BoardGame>(model);
            _rentalContext.BoardGames.Remove(entity);
        }

        public void Update(BoardGame model)
        {
            var entity = _mapper.Map<Entities.BoardGame>(model);
            _rentalContext.BoardGames.Update(entity);
        }
    }
}