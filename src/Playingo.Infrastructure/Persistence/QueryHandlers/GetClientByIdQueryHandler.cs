using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Clients.Queries;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Clients;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.QueryHandlers
{
    internal class GetClientByIdQueryHandler : IQueryHandler<GetClientByIdQuery, Client>
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