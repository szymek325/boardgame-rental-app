using Playingo.Application.Common.Mediator;
using Playingo.Domain.Clients;

namespace Playingo.Application.Interfaces.DataAccess.Commands
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