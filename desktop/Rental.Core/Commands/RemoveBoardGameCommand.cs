using System;
using Rental.CQRS;

namespace Rental.Core.Commands
{
    public class RemoveBoardGameCommand : ICommand
    {
        public RemoveBoardGameCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}