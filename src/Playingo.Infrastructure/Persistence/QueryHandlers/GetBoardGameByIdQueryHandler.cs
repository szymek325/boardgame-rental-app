using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.BoardGames.Queries;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.BoardGames;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.QueryHandlers
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