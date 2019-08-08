using Rental.Core.Interfaces.DataAccess;
using Rental.Core.Models;
using Rental.WPF.Events;

namespace Rental.WPF.ViewModel.Clients
{
    public class AddClientViewModel
    {
        private string _contactNumber;
        private string _emailAddress;
        private string _firstName;

        private string _lastName;

        public AddClientViewModel(IUnitOfWork unitOfWork)
        {
            ButtonClickCommand = new DelegateCommand<string>(
                s =>
                {
                    var user = new Client(FirstName, LastName, ContactNumber, EmailAddress);
                    unitOfWork.ClientsRepository.Add(user);
                    unitOfWork.SaveChanges();
                    ClientEvents.RaiseOnNewClientAdded(this, user);
                },
                s => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) &&
                     !string.IsNullOrEmpty(ContactNumber) && !string.IsNullOrEmpty(EmailAddress)
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

        public string ContactNumber
        {
            get => _contactNumber;
            set
            {
                _contactNumber = value;
                ButtonClickCommand.RaiseCanExecuteChanged();
            }
        }

        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                ButtonClickCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand<string> ButtonClickCommand { get; }
    }
}