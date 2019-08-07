using System.Windows;
using System.Windows.Controls;
using Rental.WPF.View.Clients;
using Rental.WPF.ViewModel;

namespace Rental.WPF.View
{
    /// <summary>
    ///     Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage(ClientListViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void AddClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            var subWindow = new AddClientWindow();
            subWindow.Show();
        }
    }
}