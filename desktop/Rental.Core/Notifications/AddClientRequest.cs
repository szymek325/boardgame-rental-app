using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Notifications
{
    public class AddClientRequest : INotification
    {
        public AddClientRequest(Client client)
        {
            Client = client;
        }

        public Client Client { get; set; }
    }
}