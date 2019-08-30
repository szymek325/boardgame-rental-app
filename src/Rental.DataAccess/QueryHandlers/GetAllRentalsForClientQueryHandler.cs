using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.CQS;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.QueryHandlers
{
    internal class
        GetAllRentalsForClientQueryHandler : IQueryHandler<GetAllRentalsForClientQuery,
            IList<Core.Models.Rentals.Rental>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllRentalsForClientQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<Core.Models.Rentals.Rental>> Handle(GetAllRentalsForClientQuery query,
            CancellationToken cancellationToken)
        {
            var entities = await _rentalContext.Rentals.Where(x => x.ClientId == query.ClientId)
                .ToListAsync(cancellationToken);
            var mappedRentals = _mapper.Map<IList<Core.Models.Rentals.Rental>>(entities);
            return mappedRentals;
        }
    }
}