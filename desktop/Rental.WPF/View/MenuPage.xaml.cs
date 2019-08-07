using System;
using System.Windows;
using System.Windows.Controls;
using Rental.Core.Interfaces.DataAccess;

namespace Rental.WPF.View
{
    /// <summary>
    ///     Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private readonly ClientsPage _clientsPage;
        private readonly IUnitOfWork _unitOfWork;

        public MenuPage(ClientsPage clientsPage, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _clientsPage = clientsPage;
            _unitOfWork = unitOfWork;
        }


        private void GoToRentals(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GoToClients(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new ClientsPage());
        }

        private void GoToGames(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}