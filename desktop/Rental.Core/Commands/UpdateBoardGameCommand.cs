using System;
using MediatR;
using Rental.Common;

namespace Rental.Core.Commands
{
    internal class UpdateBoardGameCommand : ICommand
    {
        public UpdateBoardGameCommand(Guid id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; }
        public string Name { get; }
        public float Price { get; }
    }
}