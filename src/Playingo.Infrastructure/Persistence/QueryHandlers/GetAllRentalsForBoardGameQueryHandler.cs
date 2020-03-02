using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Rentals.Queries;
using Playingo.Domain.Rentals;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.QueryHandlers
{
    internal class
        GetAllRentalsForBoardGameQueryHandler : IQueryHandler<GetAllRentalsForBoardGameQuery,
            IList<Rental>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllRentalsForBoardGameQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<Rental>> Handle(GetAllRentalsForBoardGameQuery query,
            CancellationToken cancellationToken)
        {
            var entities = await _rentalContext.Rentals.Where(x => x.BoardGameId == query.BoardGameId)
                .ToListAsync(cancellationToken);
            var mappedRentals = _mapper.Map<IList<Rental>>(entities);
            return mappedRentals;
        }
    }
}