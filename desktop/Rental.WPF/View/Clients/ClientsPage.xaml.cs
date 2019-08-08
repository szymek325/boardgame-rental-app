using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MediatR;
using Rental.Core.Models;
using Rental.Core.Notifications;
using Rental.WPF.ViewModel.Clients;

namespace Rental.WPF.View.Clients
{
    /// <summary>
    ///     Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage(INotificationHandler<NewClientAddedNotification> viewModel)
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