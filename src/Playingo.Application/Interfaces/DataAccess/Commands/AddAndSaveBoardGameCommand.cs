using Playingo.Application.Common.Mediator;
using Playingo.Domain.BoardGames;

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