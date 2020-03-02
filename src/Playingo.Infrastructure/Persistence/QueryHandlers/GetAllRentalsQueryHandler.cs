using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Domain.Rentals;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.QueryHandlers
{
    internal class GetAllRentalsQueryHandler : IQueryHandler<GetAllRentalsQuery, IList<Rental>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllRentalsQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<Rental>> Handle(GetAllRentalsQuery query,
            CancellationToken cancellationToken)
        {
            var entities = await _rentalContext.Rentals.ToListAsync(cancellationToken);
            var mappedRentals = _mapper.Map<IList<Rental>>(entities);
            return mappedRentals;
        }
    }
}