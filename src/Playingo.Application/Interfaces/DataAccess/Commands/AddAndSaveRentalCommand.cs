using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Commands
{
    public class AddAndSaveRentalCommand : ICommand
    {
        public AddAndSaveRentalCommand(Domain.Rentals.Rental rental)
        {
            Rental = rental;
        }

        public Domain.Rentals.Rental Rental { get; set; }
    }
}