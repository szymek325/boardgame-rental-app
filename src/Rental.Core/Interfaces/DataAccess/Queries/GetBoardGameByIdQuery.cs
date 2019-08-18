using System;
using Rental.Core.Models;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetBoardGameByIdQuery : IQuery<BoardGame>
    {
        public GetBoardGameByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}