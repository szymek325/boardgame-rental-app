using Playingo.Domain.Clients;
using Rental.CQS;

namespace Playingo.Application.Interfaces.DataAccess.Commands
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