using System;
using MediatR;

namespace Rental.Core.Requests
{
    internal class UpdateBoardGameRequest : IRequest<string>
    {
        public UpdateBoardGameRequest(Guid id, string name, float price)
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