using System;
using MediatR;

namespace Rental.Core.Requests
{
    public class AddBoardGameRequest : IRequest<AddBoardGameRequestResult>
    {
        public AddBoardGameRequest(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public float Price { get; set; }
    }

    public class AddBoardGameRequestResult
    {
        public AddBoardGameRequestResult(Guid newGameBoardGuid)
        {
            NewGameBoardGuid = newGameBoardGuid;
        }

        public AddBoardGameRequestResult(string message)
        {
            NewGameBoardGuid = Guid.Empty;
            Message = message;
        }

        public Guid NewGameBoardGuid { get; }
        public string Message { get; }
    }
}