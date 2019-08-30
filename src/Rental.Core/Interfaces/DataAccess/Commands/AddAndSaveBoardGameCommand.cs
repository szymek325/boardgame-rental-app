using Rental.Core.Models.BoardGames;
using Rental.CQS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class AddAndSaveBoardGameCommand : ICommand
    {
        public AddAndSaveBoardGameCommand(BoardGame boardGame)
        {
            BoardGame = boardGame;
        }

        public BoardGame BoardGame { get; }
    }
}