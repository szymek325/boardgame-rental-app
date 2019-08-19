using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.CQRS;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.QueryHandlers
{
    internal class GetRentalByIdQueryHandler : IQueryHandler<GetRentalByIdQuery, Core.Models.Rental>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetRentalByIdQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<Core.Models.Rental> Handle(GetRentalByIdQuery query, CancellationToken cancellationToken)
        {
            var entity =
                await _rentalContext.Rentals.SingleOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            var mappedEntity = _mapper.Map<Core.Models.Rental>(entity);
            return mappedEntity;
        }
    }
}