using System;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Domain.Clients;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly RentalContext _context;

        public ClientRepository(RentalContext context)
        {
            _context = context;
        }

        public Task AddASync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}