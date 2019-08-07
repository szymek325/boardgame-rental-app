using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Rental.WPF.View
{
    /// <summary>
    ///     Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            // Don't allow refreshing of a static page
            if ((e.NavigationMode == NavigationMode.Refresh) &&
                (e.Uri.OriginalString == "StaticPage.xaml"))
            {
                e.Cancel = true;
            }
        }
    }
}