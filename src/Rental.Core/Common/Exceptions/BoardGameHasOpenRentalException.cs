using System;

namespace Rental.Core.Common.Exceptions
{
    internal class BoardGameHasOpenRentalException : Exception
    {
        public BoardGameHasOpenRentalException(Guid guid) : base($"BoardGame with id {guid} is rented!")
        {
        }
    }
}