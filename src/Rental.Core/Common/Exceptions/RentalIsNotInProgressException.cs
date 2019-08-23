using System;

namespace Rental.Core.Common.Exceptions
{
    internal class RentalNotFoundException : Exception
    {
        public RentalNotFoundException(Guid guid) : base($"Rental with id {guid} was not found!")
        {
        }
    }
}