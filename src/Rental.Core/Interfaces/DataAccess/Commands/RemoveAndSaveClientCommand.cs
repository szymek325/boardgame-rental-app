using Rental.Core.Models;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class RemoveAndSaveClientCommand : ICommand
    {
        public RemoveAndSaveClientCommand(Client client)
        {
            Client = client;
        }

        public Client Client { get; set; }
    }
}