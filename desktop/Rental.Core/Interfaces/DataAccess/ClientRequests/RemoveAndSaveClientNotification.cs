using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.ClientRequests
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