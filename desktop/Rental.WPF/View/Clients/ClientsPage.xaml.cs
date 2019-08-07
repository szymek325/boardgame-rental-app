using System.Windows.Controls;
using Rental.WPF.ViewModel.Clients;

namespace Rental.WPF.View.Clients
{
    /// <summary>
    ///     Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage(ClientsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}