using Rental.Core.Models.Clients;
using Rental.CQS;

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