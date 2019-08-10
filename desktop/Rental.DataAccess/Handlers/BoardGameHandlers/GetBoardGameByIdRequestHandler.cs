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
    internal class GetBoardGameByIdRequestHandler : IRequestHandler<GetBoardGameByIdRequest, BoardGame>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetBoardGameByIdRequestHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<BoardGame> Handle(GetBoardGameByIdRequest request, CancellationToken cancellationToken)
        {
            var entity =
                await _rentalContext.BoardGames.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            var result = _mapper.Map<BoardGame>(entity);
            return result;
        }
    }
}