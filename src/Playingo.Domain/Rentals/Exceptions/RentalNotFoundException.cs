using System;

namespace Playingo.Domain.Rentals.Exceptions
{
    public class RentalIsNotInProgressException : Exception
    {
        public RentalIsNotInProgressException(Guid guid) : base($"Rental with id {guid} is not in progress status!")
        {
        }
    }
}