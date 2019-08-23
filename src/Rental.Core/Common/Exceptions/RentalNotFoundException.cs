using System;

namespace Rental.Core.Common.Exceptions
{
    internal class RentalIsNotInProgressException : Exception
    {
        public RentalIsNotInProgressException(Guid guid) : base($"Rental with id {guid} is not in progress status!")
        {
        }
    }
}