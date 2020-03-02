﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Domain.Clients;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.QueryHandlers
{
    internal class GetAllClientsQueryHandler : IQueryHandler<GetAllClientsQuery, IList<Client>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllClientsQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<Client>> Handle(GetAllClientsQuery query, CancellationToken cancellationToken)
        {
            var clients = await _rentalContext.Clients.ToListAsync(cancellationToken);
            var mappedClients = _mapper.Map<IList<Client>>(clients);
            return mappedClients;
        }
    }
}