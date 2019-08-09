using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Rental.Core.Interfaces.DataAccess;
using Rental.Core.Models;
using Rental.DataAccess.Context;

namespace Rental.DataAccess.Handlers
{
    internal class AddAndSaveClientRequestHandler : IRequestHandler<AddAndSaveClientRequest, Client>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public AddAndSaveClientRequestHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<Client> Handle(AddAndSaveClientRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Entities.Client>(request.Client);
            await _rentalContext.Clients.AddAsync(entity, cancellationToken);
            var result = _mapper.Map<Client>(entity);
            return result;
        }
    }
}