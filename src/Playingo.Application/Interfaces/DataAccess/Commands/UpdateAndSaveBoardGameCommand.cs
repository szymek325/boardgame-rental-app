using Playingo.Domain.BoardGames;
using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Commands
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