using System.Windows;
using System.Windows.Controls;
using Rental.WPF.View.Clients;
using Rental.WPF.View.Games;
using Rental.WPF.View.Rentals;

namespace Rental.WPF.View.Base
{
    /// <summary>
    ///     Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private readonly ClientsPage _clientsPage;
        private readonly GamesPage _gamesPage;
        private readonly RentalsPage _rentalsPage;

        public MenuPage(ClientsPage clientsPage, GamesPage gamesPage, RentalsPage rentalsPage)
        {
            InitializeComponent();
            _clientsPage = clientsPage;
            _gamesPage = gamesPage;
            _rentalsPage = rentalsPage;
        }


        private void GoToRentals(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(_rentalsPage);
        }

        private void GoToClients(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(_clientsPage);
        }

        private void GoToGames(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(_gamesPage);
        }
    }
}