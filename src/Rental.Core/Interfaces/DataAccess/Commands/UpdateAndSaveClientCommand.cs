using Rental.Core.Models;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class UpdateAndSaveClientCommand : ICommand
    {
        public UpdateAndSaveClientCommand(Client client)
        {
            Client = client;
        }

        public Client Client { get; set; }
    }
}