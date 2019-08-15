using System;
using MediatR;
using Rental.Common;

namespace Rental.Core.Commands
{
    public class RemoveBoardGameCommand : ICommand
    {
        public RemoveBoardGameCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}