using Playingo.Domain.BoardGames;
using Rental.CQS;

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