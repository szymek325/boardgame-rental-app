using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess;
using Rental.Core.Interfaces.DataAccess.Client;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.Client
{
    internal class GetAllClientsRequestHandler : IRequestHandler<GetAllClientsRequest, IList<Core.Models.Client>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllClientsRequestHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<Core.Models.Client>> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
        {
            var clients = await _rentalContext.Clients.ToListAsync(cancellationToken);
            var mappedClients = _mapper.Map<IList<Core.Models.Client>>(clients);
            return mappedClients;
        }
    }
}