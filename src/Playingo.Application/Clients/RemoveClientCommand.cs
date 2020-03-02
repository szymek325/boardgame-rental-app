using System;
using Rental.CQS;

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