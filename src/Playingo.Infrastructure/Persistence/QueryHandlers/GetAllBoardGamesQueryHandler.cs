using System.Collections.Generic;
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
    internal class GetAllBoardGamesQueryHandler : IQueryHandler<GetAllBoardGamesQuery, IList<BoardGame>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllBoardGamesQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<BoardGame>> Handle(GetAllBoardGamesQuery query, CancellationToken cancellationToken)
        {
            var boardGames = await _rentalContext.BoardGames.ToListAsync(cancellationToken);
            var mappedBoardGames = _mapper.Map<IList<BoardGame>>(boardGames);
            return mappedBoardGames;
        }
    }
}