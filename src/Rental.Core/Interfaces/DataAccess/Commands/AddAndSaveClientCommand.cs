﻿using Rental.Core.Models.Clients;
using Rental.CQRS;

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