using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Rentals.Queries
{
    public class GetAllRentalsForClientQuery : IQuery<IList<Rental>>
    {
        public GetAllRentalsForClientQuery(Guid clientId)
        {
            ClientId = clientId;
        }

        public Guid ClientId { get; }
    }

    internal class
        GetAllRentalsForClientQueryHandler : IQueryHandler<GetAllRentalsForClientQuery,
            IList<Rental>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRentalsForClientQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Rental>> Handle(GetAllRentalsForClientQuery query,
            CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.RentalRepository.GetAllForClientAsync(query.ClientId, cancellationToken);
            return entities;
        }
    }
}