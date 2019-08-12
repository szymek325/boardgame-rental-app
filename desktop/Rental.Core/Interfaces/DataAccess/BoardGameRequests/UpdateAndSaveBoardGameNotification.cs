using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.BoardGameRequests
{
    public class UpdateAndSaveBoardGameNotification : INotification
    {
        public UpdateAndSaveBoardGameNotification(BoardGame boardGame)
        {
            BoardGame = boardGame;
        }

        public BoardGame BoardGame { get; set; }
    }
}