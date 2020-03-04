using System;

namespace Playingo.Domain.Clients.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(Guid guid) : base($"Client with id {guid} was not found!")
        {
        }
    }
}