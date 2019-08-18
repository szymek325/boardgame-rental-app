using Rental.Core.Models;
using Rental.CQRS;

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