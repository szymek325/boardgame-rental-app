using System;
using MediatR;
using Rental.Common;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class CheckIfClientCanBeRemovedQuery : IQuery<bool>
    {
        public CheckIfClientCanBeRemovedQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}