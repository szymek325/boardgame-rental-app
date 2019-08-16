using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using AutoMapper;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.CQRS;
using Rental.WPF.Command;
using Rental.WPF.Events;
using Rental.WPF.View.Clients;

namespace Rental.WPF.ViewModel.Clients
{
    public class ClientsViewModel
    {
        private readonly ICollectionView _clientsView;
        private readonly IMapper _mapper;
        private readonly IMediatorService _mediatorService;
        private AddClientWindow _addClientWindow;
        private string _filter;

        public ClientsViewModel(IMapper mapper, IMediatorService mediatorService)
        {
            ClientEvents.OnNewClientAdded += UpdateClientIfNewUserWasAdded;
            _mediatorService = mediatorService;
            _mapper = mapper;
            Clients = new ObservableCollection<Client>(GetClients());
            _clientsView = CollectionViewSource.GetDefaultView(Clients);
            _clientsView.Filter = o =>
            {
                if (string.IsNullOrEmpty(Filter))
                    return true;
                var client = (Client) o;
                if (client.FirstName.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
                if (client.LastName.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
                if (client.ContactNumber.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
                return client.EmailAddress.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0;
            };
            ButtonClickCommand = new Command<string>(
                s =>
                {
                    _addClientWindow = new AddClientWindow(new AddClientViewModel(_mediatorService));
                    _addClientWindow.Show();
                },
                s => true
            );
            ButtonClickCommand.RaiseCanExecuteChanged();

            OnRowDoubleClick = new Command<Client>(s =>
            {
                //TODO new page should not be created here
                Trace.WriteLine($"test row {s.FirstName}");
                var p = new ClientPage(s);
                p.Show();
            });
        }

        public Command<string> ButtonClickCommand { get; }

        public ObservableCollection<Client> Clients { get; }

        public string Filter
        {
            get => _filter;
            set
            {
                if (value != _filter)
                {
                    _filter = value;
                    _clientsView.Refresh();
                }
            }
        }

        public Command<Client> OnRowDoubleClick { get; }

        private void UpdateClientIfNewUserWasAdded(object sender, Client e)
        {
            Clients.Add(e);
            _clientsView.Refresh();
            _addClientWindow.Close();
        }

        private List<Client> GetClients()
        {
            var clients = _mediatorService.Send(new GetAllClientsQuery()).Result;
            return clients.ToList();
        }

        //public void OnRowDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    var item = ((FrameworkElement)e.OriginalSource).DataContext as Client;
        //    if (item != null)
        //    {
        //        MessageBox.Show("Item's Double Click handled!");
        //    }
        //}
    }
}