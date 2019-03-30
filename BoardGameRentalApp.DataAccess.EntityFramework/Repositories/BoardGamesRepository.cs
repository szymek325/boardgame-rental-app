﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqlServer.Context;

namespace BoardGameRentalApp.DataAccess.SqlServer.Repositories
{
    internal class BoardGamesRepository : IBoardGamesRepository
    {
        private readonly BoardGameRentalMsSqlContext _msSqlContext;

        public BoardGamesRepository(BoardGameRentalMsSqlContext msSqlContext)
        {
            _msSqlContext = msSqlContext;
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _msSqlContext.BoardGames.ToList();
        }

        public BoardGame Get(int? id)
        {
            return _msSqlContext.BoardGames.FirstOrDefault(x => x.Id == id);
        }

        public void Add(BoardGame entity)
        {
            _msSqlContext.BoardGames.Add(entity);
        }

        public async Task AddAsync(BoardGame entity)
        {
            await _msSqlContext.BoardGames.AddAsync(entity);
        }

        public void Remove(BoardGame entity)
        {
            _msSqlContext.BoardGames.Remove(entity);
        }

        public void Update(BoardGame entity)
        {
            _msSqlContext.BoardGames.Update(entity);
        }
    }
}