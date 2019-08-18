using System;

namespace Rental.Core.Common.Exceptions
{
    internal class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(Guid guid) : base($"Client with id {guid} was not found!")
        {
        }
    }
}