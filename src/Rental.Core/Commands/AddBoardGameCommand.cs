using System;
using Rental.CQRS;

namespace Rental.Core.Commands
{
    public class AddBoardGameCommand : ICommand
    {
        public AddBoardGameCommand(Guid newBoardGameGuid, string name, decimal price)
        {
            NewBoardGameGuid = newBoardGameGuid;
            Name = name;
            Price = price;
        }

        public Guid NewBoardGameGuid { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}