using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using AutoMapper;
using Rental.Core.Entities;
using Rental.Core.Interfaces.DataAccess;
using Rental.WPF.Events;
using Rental.WPF.View.Clients;

namespace Rental.WPF.ViewModel.Clients
{
    public class ClientsViewModel
    {
        private readonly ICollectionView _clientsView;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private AddClientWindow _addClientWindow;
        private string _filter;

        public ClientsViewModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ClientEvents.OnNewClientAdded += UpdateClientIfNewUserWasAdded;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            Clients = new ObservableCollection<Client>(GetEmployees());
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
            ButtonClickCommand = new DelegateCommand<string>(
                s =>
                {
                    _addClientWindow = new AddClientWindow(new AddClientViewModel(unitOfWork));
                    _addClientWindow.Show();
                },
                s => true
            );
            ButtonClickCommand.RaiseCanExecuteChanged();

            OnRowDoubleClick = new DelegateCommand<Client>(s => { Trace.WriteLine($"test row {s.FirstName}"); });

        }

        public DelegateCommand<string> ButtonClickCommand { get; }

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

        private void UpdateClientIfNewUserWasAdded(object sender, Client e)
        {
            Clients.Add(e);
            _clientsView.Refresh();
            _addClientWindow.Close();
        }

        private List<Client> GetEmployees()
        {
            var clients = _unitOfWork.ClientsRepository.GetAll();
            return clients.ToList();
        }
        public DelegateCommand<Client> OnRowDoubleClick { get; }

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