using FitnessApp.Model;
using FitnessApp.ViewModel;
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
using System.Windows.Shapes;

namespace FitnessApp.View
{
    /// <summary>
    /// Interaction logic for UpdateCustomerDialog.xaml
    /// </summary>
    /// 

    public partial class UpdateCustomerDialog : Window
    {
        MainViewModel mvm = new MainViewModel()
        {
            cvm = new CustomerViewModel(),
            ehm = new ErrorHandlingViewModel()
        };

        CustomerController customerController;
        public UpdateCustomerDialog()
        {
            InitializeComponent();

            customerController = new CustomerController();

            DataContext = mvm;

        }

        private void lbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer customer = lbCustomer.SelectedItem as Customer;
            if (customer.Newsletter == true)
            {
                cbTrue.IsChecked = true;
                cbFalse.IsChecked = false;
            }
            else if (customer.Newsletter == false)
            {
                cbFalse.IsChecked = true;
                cbTrue.IsChecked = false;
            }
           

        }

        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            bool newsletter = true;

            if (cbTrue.IsChecked == true)
                newsletter = true;
            else if (cbFalse.IsChecked == true)
                newsletter = false;

            bool membershipCondition = true;
            if (cbAcceptOfPayment.IsChecked == true)
                membershipCondition = true;
            else if (cbAcceptOfPayment.IsChecked == false)
                membershipCondition = false;

            bool consent = true;
            if (cbAcceptOfConsent.IsChecked == true)
                consent = true;
            else if (cbAcceptOfConsent.IsChecked == false)
                consent = false;

            Customer customer = lbCustomer.SelectedItem as Customer;


            customerController.UpdateSelectedCustomer(customer.ID, tbName.Text, tbCprNumber.Text, int.Parse(cbAge.Text), tbAddress.Text, int.Parse(tbZipCode.Text), tbCity.Text, tbEmail.Text, tbTelephoneNumber.Text, newsletter, int.Parse(tbRegisterNumber.Text), long.Parse(tbContoNumber.Text), membershipCondition, consent);
            this.DialogResult = true;

        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = lbCustomer.SelectedItem as Customer;
            customerController.DeleteSelectedCustomer(customer.ID);
            this.DialogResult = true;
        }


        public void SetButton()
        {
            btnUpdateCustomer.IsEnabled = (tbName.Text != "") && (tbCprNumber.Text != "") && (cbAge.SelectedItem != null) && (tbAddress.Text != "") && (tbZipCode.Text != "") && (tbCity.Text != "") && (tbEmail.Text != "") && (tbTelephoneNumber.Text != "") && (cbTrue.IsChecked != false || cbFalse.IsChecked != false) && (tbRegisterNumber.Text != "") && (tbContoNumber.Text != "") && (cbAcceptOfConsent.IsChecked != false) && (cbAcceptOfPayment.IsChecked != false);
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void tbCprNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void cbAge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButton();
        }

        private void tbAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void tbZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void tbCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void tbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void tbTelephoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void cbTrue_Checked(object sender, RoutedEventArgs e)
        {
            SetButton();
        }

        private void cbFalse_Checked(object sender, RoutedEventArgs e)
        {
            SetButton();
        }

        private void tbRegisterNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void tbContoNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void cbAcceptOfPayment_Checked(object sender, RoutedEventArgs e)
        {
            SetButton();
        }

        private void cbAcceptOfConsent_Checked(object sender, RoutedEventArgs e)
        {
            SetButton();
        }
    }
}
