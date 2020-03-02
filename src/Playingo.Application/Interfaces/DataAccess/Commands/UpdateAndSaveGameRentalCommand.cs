using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Commands
{
    public class UpdateAndSaveGameRentalCommand : ICommand
    {
        public UpdateAndSaveGameRentalCommand(Domain.Rentals.Rental rental)
        {
            Rental = rental;
        }

        public Domain.Rentals.Rental Rental { get; set; }
    }
}