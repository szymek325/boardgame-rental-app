using Playingo.Domain.Clients;
using Rental.CQS;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class AddAndSaveClientCommand : ICommand
    {
        public AddAndSaveClientCommand(Client client)
        {
            Client = client;
        }

        public Client Client { get; }
    }
}