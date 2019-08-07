using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using AutoMapper;
using Rental.Core.Interfaces.DataAccess;
using Rental.WPF.ViewModel.Clients;

namespace Rental.WPF.ViewModel
{
    internal class ClientListViewModel : INotifyPropertyChanged
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientListViewModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            ClientsList = new ObservableCollection<AddClientViewModel>(GetEmployees());
            _view = new ListCollectionView(_clientsList);
        }

        //created for testing
        private List<AddClientViewModel> GetEmployees()
        {
            var clients = _unitOfWork.ClientsRepository.GetAll();
            var mapped = _mapper.Map<IEnumerable<AddClientViewModel>>(clients);
            return mapped.ToList();
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        #endregion

        #region nonModifiedCode

        private ListCollectionView _clientsCol;

        public ICollectionView ClientsCollection => _clientsCol;

        private ObservableCollection<AddClientViewModel> _clientsList;

        public ObservableCollection<AddClientViewModel> ClientsList
        {
            get => _clientsList;
            set
            {
                _clientsList = value;
                OnPropertyChanged("ClientsList");
            }
        }

        private readonly ListCollectionView _view;

        public ICollectionView View => _view;

        private string _TextSearch;

        public string TextSearch
        {
            get => _TextSearch;
            set
            {
                _TextSearch = value;
                OnPropertyChanged("TextSearch");

                if (string.IsNullOrEmpty(value))
                    View.Filter = null;
                else
                    View.Filter = o => ((AddClientViewModel) o).FirstName == value;
            }
        }

        #endregion
    }
}