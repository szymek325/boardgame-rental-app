using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.EntityFrameworkCore.Metadata;
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
            this.ClientsGrid.ItemsSource = _unitOfWork.ClientsRepository.GetAll().ToList();
        }


    }
}