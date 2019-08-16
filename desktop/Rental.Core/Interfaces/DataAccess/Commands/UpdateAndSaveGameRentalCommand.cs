using Rental.Core.Models;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class UpdateAndSaveGameRentalCommand : ICommand
    {
        public UpdateAndSaveGameRentalCommand(GameRental gameRental)
        {
            GameRental = gameRental;
        }

        public GameRental GameRental { get; set; }
    }
}