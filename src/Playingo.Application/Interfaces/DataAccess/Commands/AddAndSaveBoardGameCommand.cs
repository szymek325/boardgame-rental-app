using Playingo.Domain.BoardGames;
using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Commands
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