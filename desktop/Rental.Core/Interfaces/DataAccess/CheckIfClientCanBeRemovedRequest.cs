using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess
{
    public class CheckIfClientCanBeRemovedRequest : IRequest<bool>
    {
        public CheckIfClientCanBeRemovedRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}