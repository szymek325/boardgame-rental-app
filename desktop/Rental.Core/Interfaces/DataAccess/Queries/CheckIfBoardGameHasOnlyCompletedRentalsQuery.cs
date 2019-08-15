using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class CheckIfBoardGameHasOnlyCompletedRentalsQuery : IRequest<bool>
    {
        public CheckIfBoardGameHasOnlyCompletedRentalsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}