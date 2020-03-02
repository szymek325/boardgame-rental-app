using System;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.BoardGames
{
    public class RemoveBoardGameCommand : ICommand
    {
        public RemoveBoardGameCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}