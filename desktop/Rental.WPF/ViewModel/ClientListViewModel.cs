using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using AutoMapper;
using Rental.Core.Entities;
using Rental.Core.Interfaces.DataAccess;

namespace Rental.WPF.ViewModel
{
    public class ClientListViewModel
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICollectionView clientsView;
        private string filter;

        public ClientListViewModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            Clients = new ObservableCollection<Client>(GetEmployees());
            clientsView = CollectionViewSource.GetDefaultView(Clients);
            clientsView.Filter = o =>
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
        }

        public ObservableCollection<Client> Clients { get; }

        public string Filter
        {
            get => filter;
            set
            {
                if (value != filter)
                {
                    filter = value;
                    clientsView.Refresh();
                }
            }
        }

        //created for testing
        private List<Client> GetEmployees()
        {
            var clients = _unitOfWork.ClientsRepository.GetAll();
            return clients.ToList();
        }
    }
}