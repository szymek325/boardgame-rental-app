using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.QueryHandlers
{
    internal class
        GetAllRentalsForClientQueryHandler : IQueryHandler<GetAllRentalsForClientQuery,
            IList<Playingo.Domain.Rentals.Rental>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllRentalsForClientQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<Playingo.Domain.Rentals.Rental>> Handle(GetAllRentalsForClientQuery query,
            CancellationToken cancellationToken)
        {
            var entities = await _rentalContext.Rentals.Where(x => x.ClientId == query.ClientId)
                .ToListAsync(cancellationToken);
            var mappedRentals = _mapper.Map<IList<Playingo.Domain.Rentals.Rental>>(entities);
            return mappedRentals;
        }
    }
}