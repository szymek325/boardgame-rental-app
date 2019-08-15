using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class AddAndSaveClientCommand : INotification
    {
        public AddAndSaveClientCommand(Client client)
        {
            Client = client;
        }

        public Client Client { get; }
    }
}