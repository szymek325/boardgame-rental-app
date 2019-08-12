using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.BoardGameHandlers
{
    internal class GetAllBoardGamesRequestHandler : IRequestHandler<GetAllBoardGamesRequest, IList<BoardGame>>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetAllBoardGamesRequestHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<IList<BoardGame>> Handle(GetAllBoardGamesRequest request, CancellationToken cancellationToken)
        {
            var boardGames = await _rentalContext.BoardGames.ToListAsync(cancellationToken);
            var mappedBoardGames = _mapper.Map<IList<BoardGame>>(boardGames);
            return mappedBoardGames;
        }
    }
}