using System;

namespace Playingo.Domain.BoardGames.Exceptions
{
    public class BoardGameNotFoundException : Exception
    {
        public BoardGameNotFoundException(Guid guid) : base($"BoardGame with id {guid} was not found!")
        {
        }
    }
}