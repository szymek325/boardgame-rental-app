using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.BoardGameRequests
{
    public class AddAndSaveBoardGameRequest : IRequest<BoardGame>
    {
        public AddAndSaveBoardGameRequest(BoardGame boardGame)
        {
            BoardGame = boardGame;
        }

        public BoardGame BoardGame { get; }
    }
}