using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic.ApplicationServices;
using Rental.Core.Interfaces.DataAccess;
using Rental.WPF.View;

namespace Rental.WPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IUnitOfWork unitOfWork, ClientsPage clientsPage)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _clientsPage = clientsPage;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly ClientsPage _clientsPage;

        public MainWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            //_unitOfWork = unitOfWork;
            //var users = _unitOfWork.ClientsRepository.GetAll().ToList();
            //Users.ItemsSource = users;
            //this.Content = new ClientsPage();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RandomNumber_Click(object sender, RoutedEventArgs e)
        {
            //MyTextBox.Text = "dsadsadsa";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var users = _unitOfWork.ClientsRepository.GetAll().ToList();
            //Users.ItemsSource = users;
        }

        private void GoToRentals(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void GoToClients(object sender, RoutedEventArgs e)
        {
            this.Content = _clientsPage;
        }

        private void GoToGames(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}