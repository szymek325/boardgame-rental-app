﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqLite.Context;
using Microsoft.EntityFrameworkCore;

namespace BoardGameRentalApp.DataAccess.SqLite.Repositories
{
    internal class ClientsRepository : IClientsRepository
    {
        private readonly SqLiteContext _sqLiteContext;

        public ClientsRepository(SqLiteContext sqLiteContext)
        {
            _sqLiteContext = sqLiteContext;
        }

        public IEnumerable<Client> GetAll()
        {
            return _sqLiteContext.Clients.ToList();
        }

        public void Add(Client entity)
        {
            _sqLiteContext.Clients.Add(entity);
        }

        public async Task AddAsync(Client entity)
        {
            await _sqLiteContext.Clients.AddAsync(entity);
        }

        public void Remove(Client entity)
        {
            _sqLiteContext.Clients.Remove(entity);
        }

        public void Update(Client entity)
        {
            _sqLiteContext.Clients.Update(entity);
        }

        public Client GetWithDetails(int? id)
        {
            return _sqLiteContext.Clients
                .Include(x => x.GameRentals)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}