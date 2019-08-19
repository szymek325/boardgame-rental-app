using Rental.Core.Models.BoardGames;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class UpdateAndSaveBoardGameCommand : ICommand
    {
        public UpdateAndSaveBoardGameCommand(BoardGame boardGame)
        {
            BoardGame = boardGame;
        }

        public BoardGame BoardGame { get; set; }
    }
}