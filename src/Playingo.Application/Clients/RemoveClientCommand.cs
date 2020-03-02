using System;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.Clients
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