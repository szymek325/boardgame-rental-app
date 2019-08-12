using MediatR;

namespace Rental.Core.Requests.BoardGames
{
    public class AddBoardGameRequest : IRequest<AddRequestResult>
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