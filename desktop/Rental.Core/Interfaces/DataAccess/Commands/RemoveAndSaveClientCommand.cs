using System;
using MediatR;
using Rental.Common;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class RemoveAndSaveClientCommand : ICommand
    {
        public RemoveAndSaveClientCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}