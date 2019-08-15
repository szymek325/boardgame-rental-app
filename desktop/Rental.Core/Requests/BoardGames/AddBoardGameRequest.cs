using System;
using MediatR;

namespace Rental.Core.Requests.BoardGames
{
    public class AddBoardGameRequest : IRequest<AddRequestResult>
    {
        public AddBoardGameRequest(Guid boardGameGuid, string name, float price)
        {
            BoardGameGuid = boardGameGuid;
            Name = name;
            Price = price;
        }

        public Guid BoardGameGuid { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}