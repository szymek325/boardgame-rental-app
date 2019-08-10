using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.ClientRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.ClientHandlers
{
    internal class GetAllClientsRequestHandler : IRequestHandler<GetAllClientsRequest, IList<Client>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllClientsRequestHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<Client>> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
        {
            var clients = await _rentalContext.Clients.ToListAsync(cancellationToken);
            var mappedClients = _mapper.Map<IList<Client>>(clients);
            return mappedClients;
        }
    }
}