using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic.ApplicationServices;
using Rental.Core.Interfaces.DataAccess;

namespace Rental.WPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUnitOfWork _unitOfWork;

        public MainWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            var users = _unitOfWork.ClientsRepository.GetAll().ToList();
            Users.ItemsSource = users;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RandomNumber_Click(object sender, RoutedEventArgs e)
        {
            MyTextBox.Text = "dsadsadsa";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var users = _unitOfWork.ClientsRepository.GetAll().ToList();
            Users.ItemsSource = users;
        }
    }
}