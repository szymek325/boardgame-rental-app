using Rental.CQS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class UpdateAndSaveGameRentalCommand : ICommand
    {
        public UpdateAndSaveGameRentalCommand(Models.Rentals.Rental rental)
        {
            Rental = rental;
        }

        public Models.Rentals.Rental Rental { get; set; }
    }
}