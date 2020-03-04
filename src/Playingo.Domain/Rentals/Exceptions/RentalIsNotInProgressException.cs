using System;

namespace Playingo.Domain.Rentals.Exceptions
{
    public class RentalNotFoundException : Exception
    {
        public RentalNotFoundException(Guid guid) : base($"Rental with id {guid} was not found!")
        {
        }
    }
}