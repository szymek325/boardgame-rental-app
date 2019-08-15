using System;
using MediatR;

namespace Rental.Core.Commands
{
    public class RemoveBoardGameRequest : IRequest
    {
        public RemoveBoardGameRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}