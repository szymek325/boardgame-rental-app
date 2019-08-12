using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.BoardGameRequests
{
    public class CheckIfBoardGameHasOnlyCompletedRentalsRequest : IRequest<bool>
    {
        public CheckIfBoardGameHasOnlyCompletedRentalsRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}