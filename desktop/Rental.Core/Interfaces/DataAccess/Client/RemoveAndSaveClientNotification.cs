using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.Client
{
    public class RemoveAndSaveClientNotification : INotification
    {
        public RemoveAndSaveClientNotification(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}