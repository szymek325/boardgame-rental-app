using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.BoardGameRequests
{
    public class AddAndSaveBoardGameNotification : INotification
    {
        public AddAndSaveBoardGameNotification(BoardGame boardGame)
        {
            BoardGame = boardGame;
        }

        public BoardGame BoardGame { get; }
    }
}