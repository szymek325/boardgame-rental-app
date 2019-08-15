using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rental.Common;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.QueryHandlers
{
    internal class GetRentalByIdQueryHandler : IQueryHandler<GetRentalByIdQuery, GameRental>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetRentalByIdQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<GameRental> Handle(GetRentalByIdQuery query, CancellationToken cancellationToken)
        {
            var entity =
                await _rentalContext.GameRentals.SingleOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            var mappedEntity = _mapper.Map<GameRental>(entity);
            return mappedEntity;
        }
    }
}