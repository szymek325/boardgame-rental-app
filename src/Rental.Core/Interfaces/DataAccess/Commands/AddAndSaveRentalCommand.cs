using Rental.CQS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class AddAndSaveRentalCommand : ICommand
    {
        public AddAndSaveRentalCommand(Playingo.Domain.Rentals.Rental rental)
        {
            Rental = rental;
        }

        public Playingo.Domain.Rentals.Rental Rental { get; set; }
    }
}