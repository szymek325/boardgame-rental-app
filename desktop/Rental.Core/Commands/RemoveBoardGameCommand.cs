using System;
using MediatR;

namespace Rental.Core.Commands
{
    public class RemoveBoardGameCommand : IRequest
    {
        public RemoveBoardGameCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}