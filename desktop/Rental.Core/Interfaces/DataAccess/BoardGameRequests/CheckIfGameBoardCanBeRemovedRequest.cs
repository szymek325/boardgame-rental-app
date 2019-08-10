using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.BoardGameRequests
{
    public class CheckIfGameBoardCanBeRemovedRequest : IRequest<bool>
    {
        public CheckIfGameBoardCanBeRemovedRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}