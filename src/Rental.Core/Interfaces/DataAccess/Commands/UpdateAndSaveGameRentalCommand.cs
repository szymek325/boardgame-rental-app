using Rental.CQS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class UpdateAndSaveGameRentalCommand : ICommand
    {
        public UpdateAndSaveGameRentalCommand(Playingo.Domain.Rentals.Rental rental)
        {
            Rental = rental;
        }

        public Playingo.Domain.Rentals.Rental Rental { get; set; }
    }
}