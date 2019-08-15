using System;
using MediatR;

namespace Rental.Core.Commands
{
    public class AddBoardGameRequest : IRequest
    {
        public AddBoardGameRequest(Guid newBoardGameGuid, string name, float price)
        {
            NewBoardGameGuid = newBoardGameGuid;
            Name = name;
            Price = price;
        }

        public Guid NewBoardGameGuid { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}