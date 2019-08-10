using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.ClientRequests
{
    public class UpdateAndSaveClientNotification : INotification
    {
        public UpdateAndSaveClientNotification(Client client)
        {
            Client = client;
        }

        public Client Client { get; set; }
    }
}