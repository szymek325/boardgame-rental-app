using System.Collections.Generic;
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
    internal class GetAllBoardGamesQueryHandler : IRequestHandler<GetAllBoardGamesQuery, IList<BoardGame>>
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