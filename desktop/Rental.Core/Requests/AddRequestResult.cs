using System;

namespace Rental.Core.Requests
{
    public class AddRequestResult
    {
        public AddRequestResult(Guid newGuid)
        {
            NewGuid = newGuid;
        }

        public AddRequestResult(string message)
        {
            NewGuid = Guid.Empty;
            Message = message;
        }

        public Guid NewGuid { get; }
        public string Message { get; }
    }
}