using System.Windows.Controls;
using Rental.WPF.ViewModel;

namespace Rental.WPF.View
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