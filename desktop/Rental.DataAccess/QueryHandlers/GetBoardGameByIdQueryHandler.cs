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
    internal class GetBoardGameByIdQueryHandler : IQueryHandler<GetBoardGameByIdQuery, BoardGame>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetBoardGameByIdQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<BoardGame> Handle(GetBoardGameByIdQuery query, CancellationToken cancellationToken)
        {
            var entity =
                await _rentalContext.BoardGames.SingleOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            var result = _mapper.Map<BoardGame>(entity);
            return result;
        }
    }
}