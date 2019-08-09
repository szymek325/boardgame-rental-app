using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Notifications
{
    public class NewClientAddedNotification : INotification
    {
        public NewClientAddedNotification(Client client)
        {
            Client = client;
        }

        public Client Client { get; set; }
    }
}