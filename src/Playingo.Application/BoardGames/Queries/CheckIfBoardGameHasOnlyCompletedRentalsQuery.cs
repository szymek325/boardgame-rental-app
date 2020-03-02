using System;
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
}