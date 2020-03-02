using System;
using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Queries
{
    public class CheckIfBoardGameHasOnlyCompletedRentalsQuery : IQuery<bool>
    {
        public CheckIfBoardGameHasOnlyCompletedRentalsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}