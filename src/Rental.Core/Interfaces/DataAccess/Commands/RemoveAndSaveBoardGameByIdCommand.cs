using System;
using Rental.CQS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class RemoveAndSaveBoardGameByIdCommand : ICommand
    {
        public RemoveAndSaveBoardGameByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}