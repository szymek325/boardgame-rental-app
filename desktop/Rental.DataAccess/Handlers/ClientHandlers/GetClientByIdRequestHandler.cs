using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.ClientRequests;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers.ClientHandlers
{
    internal class GetClientByIdRequestHandler : IRequestHandler<GetClientByIdRequest, Core.Models.Client>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetClientByIdRequestHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<Core.Models.Client> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await _rentalContext.Clients.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            var result = _mapper.Map<Core.Models.Client>(entity);
            return result;
        }
    }
}