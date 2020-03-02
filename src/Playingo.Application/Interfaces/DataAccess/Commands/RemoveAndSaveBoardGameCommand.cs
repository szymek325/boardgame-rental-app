using Playingo.Domain.BoardGames;
using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Commands
{
    public class RemoveAndSaveBoardGameCommand : ICommand
    {
        public RemoveAndSaveBoardGameCommand(BoardGame boardGame)
        {
            BoardGame = boardGame;
        }

        public BoardGame BoardGame { get; set; }
    }
}