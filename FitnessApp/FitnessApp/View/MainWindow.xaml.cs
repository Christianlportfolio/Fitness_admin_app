using FitnessApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomerDialog createCustomerDialog = new CreateCustomerDialog();
            createCustomerDialog.ShowDialog();
        }

        private void btnAddPaymentInformation_Click(object sender, RoutedEventArgs e)
        {
            AddPaymentInformationDialog addPaymentInformationDialog = new AddPaymentInformationDialog();
            addPaymentInformationDialog.ShowDialog();
        }

        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            UpdateCustomerDialog updateCustomerDialog = new UpdateCustomerDialog();
            updateCustomerDialog.ShowDialog();

        }

        private void btnCreateMembership_Click(object sender, RoutedEventArgs e)
        {
            CreateMembershipDialog createMembershipDialog = new CreateMembershipDialog();
            createMembershipDialog.ShowDialog();
        }
    }
}
