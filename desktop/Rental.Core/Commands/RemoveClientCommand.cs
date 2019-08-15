using System;
using MediatR;
using Rental.Common;

namespace Rental.Core.Commands
{
    public class RemoveClientCommand : ICommand
    {
        public RemoveClientCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}