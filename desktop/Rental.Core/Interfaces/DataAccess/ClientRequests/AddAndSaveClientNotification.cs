using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.ClientRequests
{
    public class AddAndSaveClientNotification : INotification
    {
        public AddAndSaveClientNotification(Client client)
        {
            Client = client;
        }

        public Client Client { get; }
    }
}