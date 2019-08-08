using System;
using System.Threading.Tasks;
using Rental.Core.MediatR;
using Rental.Core.Models;
using Rental.Core.Notifications;
using Rental.WPF.Command;
using Rental.WPF.Events;

namespace Rental.WPF.ViewModel.Clients
{
    public class AddClientViewModel
    {
        private string _contactNumber;
        private string _emailAddress;
        private string _firstName;

        private string _lastName;

        public AddClientViewModel(IMediatorService mediatorService)
        {
            ButtonClickCommand = new AsyncCommand<string>(async s =>
                {
                    var user = new Client(FirstName, LastName, ContactNumber, EmailAddress);
                    await mediatorService.Notify(new AddClientRequest(user));
                    ClientEvents.RaiseOnNewClientAdded(this, user);
                },
                s => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) &&
                     !string.IsNullOrEmpty(ContactNumber) && !string.IsNullOrEmpty(EmailAddress)
            );
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

        public IAsyncCommand<string> ButtonClickCommand { get; private set; }
    }
}