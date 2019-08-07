using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Rental.Core.Entities;
using Rental.Core.Interfaces.DataAccess;
using Rental.WPF.View.Clients;
using static System.String;

namespace Rental.WPF.View
{
    /// <summary>
    ///     Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientsPage(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            ClientsGrid.ItemsSource = _unitOfWork.ClientsRepository.GetAll().ToList();
            var view = (CollectionView) CollectionViewSource.GetDefaultView(ClientsGrid.ItemsSource);
            view.Filter = ClientFilter;
        }

        private bool ClientFilter(object item)
        {
            if (IsNullOrEmpty(ClientFilterBox.Text))
                return true;
            var client = (Client) item;
            if (client.FirstName.IndexOf(ClientFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            if (client.LastName.IndexOf(ClientFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            if (client.ContactNumber.IndexOf(ClientFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            return client.EmailAddress.IndexOf(ClientFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ClientsGrid.ItemsSource).Refresh();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void AddClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddClientWindow subWindow = new AddClientWindow();
            subWindow.Show();
        }
    }
}