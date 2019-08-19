using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Rental.Core.Models.Clients;
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

        private void OnRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement) e.OriginalSource).DataContext as Client;
            ((ClientsViewModel) DataContext)
                .OnRowDoubleClick.Execute(item);
        }
    }
}