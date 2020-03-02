using System;

namespace Playingo.Application.Common.Exceptions
{
    internal class BoardGameNotFoundException : Exception
    {
        public BoardGameNotFoundException(Guid guid) : base($"BoardGame with id {guid} was not found!")
        {
        }
    }
}