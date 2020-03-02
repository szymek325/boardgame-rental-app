using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.QueryHandlers
{
    internal class GetRentalByIdQueryHandler : IQueryHandler<GetRentalByIdQuery, Playingo.Domain.Rentals.Rental>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetRentalByIdQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<Playingo.Domain.Rentals.Rental> Handle(GetRentalByIdQuery query,
            CancellationToken cancellationToken)
        {
            var entity =
                await _rentalContext.Rentals.SingleOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            var mappedEntity = _mapper.Map<Playingo.Domain.Rentals.Rental>(entity);
            return mappedEntity;
        }
    }
}