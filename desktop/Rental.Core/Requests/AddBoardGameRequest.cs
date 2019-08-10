using System;
using MediatR;

namespace Rental.Core.Requests
{
    public class AddBoardGameRequest : IRequest<Guid>
    {
        public AddBoardGameRequest(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public float Price { get; set; }
    }
}