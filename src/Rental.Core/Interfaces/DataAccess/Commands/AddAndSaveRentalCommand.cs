using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class AddAndSaveRentalCommand : ICommand
    {
        public AddAndSaveRentalCommand(Models.Rental rental)
        {
            Rental = rental;
        }

        public Models.Rental Rental { get; set; }
    }
}