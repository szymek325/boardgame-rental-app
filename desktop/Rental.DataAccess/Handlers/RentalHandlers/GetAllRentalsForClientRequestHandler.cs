using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.GameRentalRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.RentalHandlers
{
    internal class GetAllRentalsForClientRequestHandler : IRequestHandler<GetAllRentalsForClientRequest, IList<GameRental>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllRentalsForClientRequestHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<GameRental>> Handle(GetAllRentalsForClientRequest request, CancellationToken cancellationToken)
        {
            var entities = await _rentalContext.GameRentals.Where(x => x.ClientId == request.ClientId).ToListAsync(cancellationToken);
            var mappedRentals = _mapper.Map<IList<GameRental>>(entities);
            return mappedRentals;
        }
    }
}