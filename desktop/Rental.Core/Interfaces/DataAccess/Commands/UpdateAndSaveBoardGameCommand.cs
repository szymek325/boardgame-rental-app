using MediatR;
using Rental.Common;
using Rental.Core.Models;

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