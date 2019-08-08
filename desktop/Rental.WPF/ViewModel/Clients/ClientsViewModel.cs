using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using MediatR;
using Rental.Core.MediatR;
using Rental.Core.Models;
using Rental.Core.Notifications;
using Rental.Core.Requests;
using Rental.WPF.Command;
using Rental.WPF.View.Clients;

namespace Rental.WPF.ViewModel.Clients
{
    public class ClientsViewModel : INotificationHandler<NewClientAddedNotification>
    {
        private readonly ICollectionView _clientsView;
        private readonly IMediatorService _mediatorService;
        private AddClientWindow _addClientWindow;
        private string _filter;

        public ClientsViewModel(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;

            Clients = new ObservableCollection<Client>(_mediatorService
                .Request<IList<Client>>(new GetAllClientsRequest()).Result);
            _clientsView = CollectionViewSource.GetDefaultView(Clients);
            _clientsView.Filter = FilterClients;
            ButtonClickCommand = new DelegateCommand<string>(
                s =>
                {
                    _addClientWindow = new AddClientWindow(new AddClientViewModel(_mediatorService));
                    _addClientWindow.Show();
                },
                s => true
            );
            ButtonClickCommand.RaiseCanExecuteChanged();

            OnRowDoubleClick = new AsyncCommand<Client>(async s =>
            {
                //TODO new page should not be created here
                Trace.WriteLine($"test row {s.FirstName}");
                var p = new ClientPage(s);
                p.Show();
            });
        }

        public DelegateCommand<string> ButtonClickCommand { get; }

        public ObservableCollection<Client> Clients { get; }

        public string Filter
        {
            get => _filter;
            set
            {
                if (value == _filter) return;
                _filter = value;
                _clientsView.Refresh();
            }
        }

        public IAsyncCommand<Client> OnRowDoubleClick { get; }

        public Task Handle(NewClientAddedNotification notification, CancellationToken cancellationToken)
        {
            Trace.WriteLine("test");
            Clients.Add(notification.Client);
            _clientsView.Refresh();
            _addClientWindow.Close();
            return Task.CompletedTask;
        }

        private bool FilterClients(object o)
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
        }
    }
}