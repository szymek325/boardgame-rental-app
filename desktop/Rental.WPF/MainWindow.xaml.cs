using System.Windows;
using System.Windows.Controls;

namespace Rental.WPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
    }
}