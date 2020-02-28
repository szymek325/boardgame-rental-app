using System;
using Playingo.Domain.BoardGames;
using Rental.CQS;

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