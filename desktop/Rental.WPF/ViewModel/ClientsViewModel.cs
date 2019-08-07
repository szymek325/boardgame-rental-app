using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using AutoMapper;
using Rental.Core.Entities;
using Rental.Core.Interfaces.DataAccess;
using Rental.WPF.View.Clients;

namespace Rental.WPF.ViewModel
{
    public class ClientsViewModel
    {
        private readonly ICollectionView _clientsView;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private string _filter;

        public ClientsViewModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
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
                    var subWindow = new AddClientWindow();
                    subWindow.Show();
                },
                s => true
            );
            ButtonClickCommand.RaiseCanExecuteChanged();
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

        private List<Client> GetEmployees()
        {
            var clients = _unitOfWork.ClientsRepository.GetAll();
            return clients.ToList();
        }
    }
}