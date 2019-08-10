using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.ClientRequests
{
    public class AddAndSaveClientRequest : IRequest<Client>
    {
        public AddAndSaveClientRequest(Client client)
        {
            Client = client;
        }

        public Client Client { get; }
    }
}