using System;
using MediatR;

namespace Rental.Core.Commands
{
    public class RemoveClientRequest : IRequest
    {
        public RemoveClientRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}