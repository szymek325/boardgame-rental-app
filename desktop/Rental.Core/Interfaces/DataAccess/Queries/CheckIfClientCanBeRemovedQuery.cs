using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class CheckIfClientCanBeRemovedQuery : IRequest<bool>
    {
        public CheckIfClientCanBeRemovedQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}