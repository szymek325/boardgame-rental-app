using System;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Rentals.Queries
{
    public class GetRentalByIdQuery : IQuery<Rental>
    {
        public GetRentalByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    internal class GetRentalByIdQueryHandler : IQueryHandler<GetRentalByIdQuery, Rental>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRentalByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Rental> Handle(GetRentalByIdQuery query,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.RentalRepository.GetByIdAsync(query.Id, cancellationToken);
            return entity;
        }
    }
}