using MediatR;
using Rental.Common;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.Commands
{
    public class AddAndSaveClientCommand : ICommand
    {
        public AddAndSaveClientCommand(Client client)
        {
            Client = client;
        }

        public Client Client { get; }
    }
}