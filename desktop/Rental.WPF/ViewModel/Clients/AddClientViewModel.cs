﻿using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.ClientRequests;
using Rental.Core.Requests;
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
                    var guid = await mediatorService.Request(new AddClientRequest(FirstName, LastName, ContactNumber,
                        EmailAddress));
                    var client = await mediatorService.Request(new GetClientByIdRequest(guid));
                    ClientEvents.RaiseOnNewClientAdded(this, client);
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

        public IAsyncCommand<string> ButtonClickCommand { get; }
    }
}