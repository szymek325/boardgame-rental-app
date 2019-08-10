using System;
using MediatR;

namespace Rental.Core.Requests
{
    public class RemoveBoardGameRequest : IRequest<string>
    {
        public RemoveBoardGameRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}