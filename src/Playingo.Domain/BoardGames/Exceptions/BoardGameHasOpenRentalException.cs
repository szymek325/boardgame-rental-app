using System;

namespace Playingo.Domain.BoardGames.Exceptions
{
    public class BoardGameHasOpenRentalException : Exception
    {
        public BoardGameHasOpenRentalException(Guid guid) : base($"BoardGame with id {guid} is rented!")
        {
        }
    }
}