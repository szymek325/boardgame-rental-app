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
    internal class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Client>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetClientByIdQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<Client> Handle(GetClientByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _rentalContext.Clients.SingleOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            var result = _mapper.Map<Client>(entity);
            return result;
        }
    }
}