using System.Windows;
using System.Windows.Navigation;
using Rental.WPF.View;

namespace Rental.WPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MenuPage _menuPage;

        public MainWindow(MenuPage menuPage)
        {
            InitializeComponent();
            _menuPage = menuPage;
            this.MyFrame.Content = menuPage;
        }
    }
}