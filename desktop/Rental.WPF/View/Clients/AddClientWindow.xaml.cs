using System.Windows;
using Rental.WPF.ViewModel.Clients;

namespace Rental.WPF.View.Clients
{
    /// <summary>
    ///     Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private readonly AddClientViewModel _viewModel;

        public AddClientWindow(AddClientViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public AddClientWindow()
        {
            InitializeComponent();
            DataContext = new AddClientViewModel();
        }
    }
}