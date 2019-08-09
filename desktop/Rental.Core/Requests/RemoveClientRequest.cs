using System;
using MediatR;

namespace Rental.Core.Requests
{
    public class RemoveClientRequest : IRequest<string>
    {
        public RemoveClientRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}