using Playingo.Domain.Clients;
using Rental.CQS;

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