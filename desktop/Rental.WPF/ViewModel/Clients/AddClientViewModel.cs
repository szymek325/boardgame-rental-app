using System.Diagnostics;

namespace Rental.WPF.ViewModel.Clients
{
    public class AddClientViewModel
    {
        private string _firstName;

        private string _lastName;

        public AddClientViewModel()
        {
            ButtonClickCommand = new DelegateCommand<string>(
                s => { Trace.WriteLine(FirstName); }, //Execute
                s => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) //CanExecute
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