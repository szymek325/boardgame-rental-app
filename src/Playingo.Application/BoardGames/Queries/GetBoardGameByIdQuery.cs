using System;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.BoardGames;

namespace Playingo.Application.BoardGames.Queries
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