using System;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class RemoveAndSaveBoardGameCommand : ICommand
    {
        public RemoveAndSaveBoardGameCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}