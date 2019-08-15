using System;
using MediatR;

namespace Rental.Core.Commands
{
    public class RemoveClientCommand : IRequest
    {
        public RemoveClientCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}