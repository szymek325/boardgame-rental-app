using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.BoardGameRequests
{
    public class RemoveAndSaveGameBoardNotification : INotification
    {
        public RemoveAndSaveGameBoardNotification(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}