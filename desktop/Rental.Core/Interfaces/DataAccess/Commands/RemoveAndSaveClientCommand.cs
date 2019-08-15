using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class RemoveAndSaveClientCommand : INotification
    {
        public RemoveAndSaveClientCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}