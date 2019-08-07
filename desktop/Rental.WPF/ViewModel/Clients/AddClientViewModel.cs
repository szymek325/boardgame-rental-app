using System.Collections.ObjectModel;
using Rental.Core.Entities;
using Rental.Core.Interfaces.DataAccess;
using Rental.WPF.View.Clients;

namespace Rental.WPF.ViewModel.Clients
{
    public class AddClientViewModel
    {
        private string _firstName;

        private string _lastName;


        public AddClientViewModel(IUnitOfWork unitOfWork, ObservableCollection<Client> clients) // clients should be moved
        {
            ButtonClickCommand = new DelegateCommand<string>(
                s =>
                {
                    var user = new Client(FirstName, LastName, ContactNumber, EmailAddress);
                    unitOfWork.ClientsRepository.Add(user);
                    unitOfWork.SaveChanges();
                    clients.Add(user); //should be moved
                },
                s => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName)
            );
            ButtonClickCommand.RaiseCanExecuteChanged();
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                ButtonClickCommand.RaiseCanExecuteChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                ButtonClickCommand.RaiseCanExecuteChanged();
            }
        }

        public string ContactNumber { get; set; }

        public string EmailAddress { get; set; }

        public DelegateCommand<string> ButtonClickCommand { get; }
    }
}