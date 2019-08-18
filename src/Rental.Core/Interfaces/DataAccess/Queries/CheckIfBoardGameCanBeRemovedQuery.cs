using System;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class CheckIfBoardGameCanBeRemovedQuery : IQuery<bool>
    {
        public CheckIfBoardGameCanBeRemovedQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}