using System;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.Interfaces.DataAccess.Commands
{
    public class RemoveAndSaveClientByIdCommand : ICommand
    {
        public RemoveAndSaveClientByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}