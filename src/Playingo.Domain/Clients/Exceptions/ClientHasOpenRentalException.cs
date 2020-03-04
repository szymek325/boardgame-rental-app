using System;

namespace Playingo.Domain.Clients.Exceptions
{
    public class ClientHasOpenRentalException : Exception
    {
        public ClientHasOpenRentalException(Guid guid) : base(
            $"Client with id {guid} has rentals that are in progress!")
        {
        }
    }
}