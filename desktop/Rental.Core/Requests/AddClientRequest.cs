using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Requests
{
    public class AddClientRequest : IRequest<Client>
    {
        public AddClientRequest(Client client)
        {
            Client = client;
        }

        public Client Client { get; set; }
    }
}