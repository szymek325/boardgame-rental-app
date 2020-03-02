using System;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.BoardGames.Queries
{
    public class CheckIfBoardGameHasOnlyCompletedRentalsQuery : IQuery<bool>
    {
        public CheckIfBoardGameHasOnlyCompletedRentalsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    internal class
        CheckIfBoardGameHasOnlyCompletedRentalsQueryHandler : IQueryHandler<CheckIfBoardGameHasOnlyCompletedRentalsQuery
            , bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckIfBoardGameHasOnlyCompletedRentalsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckIfBoardGameHasOnlyCompletedRentalsQuery query,
            CancellationToken cancellationToken)
        {
            var allRentalsForBoardGameAreCompleted =
                await _unitOfWork.RentalRepository.AreAllCompletedForBoardGameAsync(query.Id, cancellationToken);
            return allRentalsForBoardGameAreCompleted;
        }
    }
}