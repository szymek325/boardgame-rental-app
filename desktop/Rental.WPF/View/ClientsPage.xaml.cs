using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.VisualBasic.ApplicationServices;
using Rental.Core.Entities;
using Rental.Core.Interfaces.DataAccess;

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

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ClientsGrid.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(ClientFilterBox.Text))
                return true;
            else
                return ((item as Client).FirstName.IndexOf(ClientFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ClientsGrid.ItemsSource).Refresh();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}