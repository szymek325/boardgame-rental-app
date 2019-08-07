using System;
using Rental.Core.Entities;

namespace Rental.WPF.Events
{
    public static class ClientEvents
    {
        public static event EventHandler<Client> OnNewClientAdded;

        public static void RaiseOnNewClientAdded(object sender, Client client)
        {
            OnNewClientAdded?.Invoke(sender, client);
        }
    }
}