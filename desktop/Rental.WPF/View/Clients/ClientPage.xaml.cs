using System.Windows;
using System.Windows.Controls;
using Rental.Core.Entities;

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