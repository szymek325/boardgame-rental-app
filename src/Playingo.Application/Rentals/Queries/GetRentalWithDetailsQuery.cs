using System;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Rentals.Queries
{
    public class GetRentalWithDetailsQuery : IQuery<RentalWithDetails>
    {
        public GetRentalWithDetailsQuery(Guid rentalGuid)
        {
            RentalGuid = rentalGuid;
        }

        public Guid RentalGuid { get; }
    }

    internal class GetRentalWithDetailsQueryHandler : IQueryHandler<GetRentalWithDetailsQuery, RentalWithDetails>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRentalWithDetailsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RentalWithDetails> Handle(GetRentalWithDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _unitOfWork.RentalRepository.GetWithDetailsByIdAsync(request.RentalGuid, cancellationToken);
            return entity;
        }
    }
}