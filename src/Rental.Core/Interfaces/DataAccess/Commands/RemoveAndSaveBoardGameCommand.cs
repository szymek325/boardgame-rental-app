using Rental.Core.Models;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class RemoveAndSaveBoardGameCommand : ICommand
    {
        public BoardGame BoardGame { get; set; }
    }
}