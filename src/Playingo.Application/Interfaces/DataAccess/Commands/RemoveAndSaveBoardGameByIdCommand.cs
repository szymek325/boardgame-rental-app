using System;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.Interfaces.DataAccess.Commands
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