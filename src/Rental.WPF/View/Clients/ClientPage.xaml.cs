using System.Windows;
using Rental.Core.Models.Clients;

namespace Rental.WPF.View.Clients
{
    /// <summary>
    ///     Interaction logic for ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Window
    {
        public ClientPage(Client client)
        {
            InitializeComponent();
            DataContext = client;
        }
    }
}