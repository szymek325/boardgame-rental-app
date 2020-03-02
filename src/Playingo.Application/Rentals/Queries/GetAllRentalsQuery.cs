using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Rentals.Queries
{
    public class GetAllRentalsQuery : IQuery<IList<Rental>>
    {
    }

    internal class GetAllRentalsQueryHandler : IQueryHandler<GetAllRentalsQuery, IList<Rental>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRentalsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Rental>> Handle(GetAllRentalsQuery query,
            CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.RentalRepository.GetAllAsync(cancellationToken);
            return entities;
        }
    }
}