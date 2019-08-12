using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.GameRentalRequests
{
    public class UpdateAndSaveGameRentalNotification : INotification
    {
        public UpdateAndSaveGameRentalNotification(GameRental gameRental)
        {
            GameRental = gameRental;
        }

        public GameRental GameRental { get; set; }
    }
}