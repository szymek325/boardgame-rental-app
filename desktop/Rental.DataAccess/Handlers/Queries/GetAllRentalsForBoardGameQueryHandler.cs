using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.Queries
{
    internal class GetAllRentalsForBoardGameQueryHandler : IRequestHandler<GetAllRentalsForBoardGameQuery, IList<GameRental>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllRentalsForBoardGameQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<GameRental>> Handle(GetAllRentalsForBoardGameQuery query, CancellationToken cancellationToken)
        {
            var entities = await _rentalContext.GameRentals.Where(x => x.BoardGameId == query.BoardGameId).ToListAsync(cancellationToken);
            var mappedRentals = _mapper.Map<IList<GameRental>>(entities);
            return mappedRentals;
        }
    }
}