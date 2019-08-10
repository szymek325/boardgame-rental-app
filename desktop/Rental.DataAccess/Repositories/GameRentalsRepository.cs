using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Repositories;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Repositories
{
    internal class GameRentalsRepository : IGameRentalsRepository
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GameRentalsRepository(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public IEnumerable<GameRental> GetAll()
        {
            var entities = _rentalContext.GameRentals;
            var result = _mapper.Map<IEnumerable<GameRental>>(entities);
            return result;
        }

        public async Task<GameRental> GetAsync(Guid? id)
        {
            var entity = await _rentalContext.GameRentals
                .Include(x => x.BoardGame)
                .Include(x => x.Client)
                .SingleOrDefaultAsync(x => x.Id == id);
            var result = _mapper.Map<GameRental>(entity);
            return result;
        }

        public async Task AddAsync(GameRental model)
        {
            var entity = _mapper.Map<Entities.GameRental>(model);
            await _rentalContext.GameRentals.AddAsync(entity);
        }

        public void Update(GameRental model)
        {
            var entity = _mapper.Map<Entities.GameRental>(model);
            _rentalContext.GameRentals.Update(entity);
        }
    }
}