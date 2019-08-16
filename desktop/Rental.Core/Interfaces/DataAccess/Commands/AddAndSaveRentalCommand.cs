using Rental.Core.Models;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class AddAndSaveRentalCommand : ICommand
    {
        public AddAndSaveRentalCommand(GameRental gameRental)
        {
            GameRental = gameRental;
        }

        public GameRental GameRental { get; set; }
    }
}