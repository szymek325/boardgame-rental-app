using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class UpdateAndSaveClientCommand : INotification
    {
        public UpdateAndSaveClientCommand(Client client)
        {
            Client = client;
        }

        public Client Client { get; set; }
    }
}