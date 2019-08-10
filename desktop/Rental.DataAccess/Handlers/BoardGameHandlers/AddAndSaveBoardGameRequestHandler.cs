using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.BoardGameHandlers
{
    internal class AddAndSaveBoardGameRequestHandler : IRequestHandler<AddAndSaveBoardGameRequest, BoardGame>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public AddAndSaveBoardGameRequestHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<BoardGame> Handle(AddAndSaveBoardGameRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Entities.BoardGame>(request.BoardGame);
            entity.CreationTime = DateTime.UtcNow;
            await _rentalContext.BoardGames.AddAsync(entity, cancellationToken);
            var result = _mapper.Map<BoardGame>(entity);
            return result;
        }
    }
}