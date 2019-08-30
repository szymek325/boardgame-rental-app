using System;
using Rental.CQRS;

namespace Rental.Core.Commands
{
    public class UpdateBoardGameCommand : ICommand
    {
        public UpdateBoardGameCommand(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; }
        public string Name { get; }
        public decimal Price { get; }
    }
}