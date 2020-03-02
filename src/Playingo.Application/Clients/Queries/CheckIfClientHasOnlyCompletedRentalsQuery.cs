using System;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.Clients.Queries
{
    public class CheckIfClientHasOnlyCompletedRentalsQuery : IQuery<bool>
    {
        public CheckIfClientHasOnlyCompletedRentalsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    internal class
        CheckIfClientHasOnlyCompletedRentalsQueryHandler : IQueryHandler<CheckIfClientHasOnlyCompletedRentalsQuery, bool
        >
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckIfClientHasOnlyCompletedRentalsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckIfClientHasOnlyCompletedRentalsQuery query,
            CancellationToken cancellationToken)
        {
            var allRentalsForClientAreCompleted =
                await _unitOfWork.RentalRepository.AreAllCompletedForClientAsync(query.Id, cancellationToken);
            return allRentalsForClientAreCompleted;
        }
    }
}