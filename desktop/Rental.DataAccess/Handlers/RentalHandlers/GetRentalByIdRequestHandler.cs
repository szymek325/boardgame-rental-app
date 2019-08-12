using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.GameRentalRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.RentalHandlers
{
    internal class GetRentalByIdRequestHandler : IRequestHandler<GetRentalByIdRequest, GameRental>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetRentalByIdRequestHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<GameRental> Handle(GetRentalByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await _rentalContext.GameRentals.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            var mappedEntity = _mapper.Map<GameRental>(entity);
            return mappedEntity;
        }
    }
}