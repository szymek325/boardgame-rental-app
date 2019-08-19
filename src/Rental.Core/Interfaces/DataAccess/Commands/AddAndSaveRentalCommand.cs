using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class AddAndSaveRentalCommand : ICommand
    {
        public AddAndSaveRentalCommand(Models.Rentals.Rental rental)
        {
            Rental = rental;
        }

        public Models.Rentals.Rental Rental { get; set; }
    }
}