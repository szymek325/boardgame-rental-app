using MediatR;
using Rental.Common;
using Rental.Core.Models;

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