using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.BoardGameRequests
{
    public class CheckIfBoardGameCanBeRemovedRequest : IRequest<bool>
    {
        public CheckIfBoardGameCanBeRemovedRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}