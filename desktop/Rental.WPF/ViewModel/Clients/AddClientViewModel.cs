using System;
using Rental.Core.Entities;
using Rental.Core.Interfaces.DataAccess;

namespace Rental.WPF.ViewModel.Clients
{
    public class AddClientViewModel
    {
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
                    ClientAddedToDb?.Invoke(this, user);
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
        public static event EventHandler<Client> ClientAddedToDb;
    }
}