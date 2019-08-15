using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Common;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.QueryHandlers
{
    internal class GetAllRentalsForClientQueryHandler : IQueryHandler<GetAllRentalsForClientQuery, IList<GameRental>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllRentalsForClientQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<GameRental>> Handle(GetAllRentalsForClientQuery query,
            CancellationToken cancellationToken)
        {
            var entities = await _rentalContext.GameRentals.Where(x => x.ClientId == query.ClientId)
                .ToListAsync(cancellationToken);
            var mappedRentals = _mapper.Map<IList<GameRental>>(entities);
            return mappedRentals;
        }
    }
}