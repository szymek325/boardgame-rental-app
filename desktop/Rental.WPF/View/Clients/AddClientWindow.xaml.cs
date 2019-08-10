using System;
using System.Windows;
using Rental.WPF.ViewModel.Clients;

namespace Rental.WPF.View.Clients
{
    /// <summary>
    ///     Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow(AddClientViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}