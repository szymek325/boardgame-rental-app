using MediatR;

namespace Rental.Core.Interfaces.DataAccess.Client
{
    public class AddAndSaveClientRequest : IRequest<Models.Client>
    {
        public AddAndSaveClientRequest(Models.Client client)
        {
            Client = client;
        }

        public Models.Client Client { get; }
    }
}