using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class UpdateAndSaveGameRentalCommand : ICommand
    {
        public UpdateAndSaveGameRentalCommand(Models.Rental rental)
        {
            Rental = rental;
        }

        public Models.Rental Rental { get; set; }
    }
}