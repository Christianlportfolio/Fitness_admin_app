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
    /// Interaction logic for AddPaymentInformationDialog.xaml
    /// </summary>
    public partial class AddPaymentInformationDialog : Window
    {

        MainViewModel mvm = new MainViewModel()
        {
            cvm = new CustomerViewModel(),
            ehm = new ErrorHandlingViewModel()
        };

        CustomerController customerController;
       

        public AddPaymentInformationDialog()
        {
            InitializeComponent();


            DataContext = mvm;

            customerController = new CustomerController();
            

            


        }

        private void btnAddPaymentInformation_Click(object sender, RoutedEventArgs e)
        {

            try
            {
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

                if (membershipCondition == true && consent == true)
                    customerController.AddPaymentInformation((lbCustomer.SelectedItem as Customer).ID, int.Parse(tbRegisterNumber.Text), long.Parse(tbContoNumber.Text), membershipCondition, consent);

              
                MessageBoxResult result = MessageBox.Show("Succes! \n\nVil du tilføje betalingsoplysninger til en anden kunde?", "Bekræftelse", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    AddPaymentInformationDialog addPaymentInformationDialog = new AddPaymentInformationDialog();
                    addPaymentInformationDialog.ShowDialog();
                }
                else if (result == MessageBoxResult.No)
                {

                }

                else
                {
                    return;
                }
            }

            catch (Exception)
            {


                MessageBoxResult result = MessageBox.Show("Ups... der er sket en fejl \n\n Vil du prøve igen?", "Fejlmeddelselse", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes)
                {
                    return;
                }
                else if (result == MessageBoxResult.No)
                {

                }
            }

            this.DialogResult = true;
        }



        private void SetButton()
        {
            btnAddPaymentInformation.IsEnabled = (tbRegisterNumber.Text != "") && (tbContoNumber.Text != "") && (cbAcceptOfConsent.IsChecked != false) && (cbAcceptOfPayment.IsChecked != false);
        }

        private void tbRegisterNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

            string errorMessage = "Må ikke indeholde bogstaver!";
            int parsedValue;

            if (!int.TryParse(tbRegisterNumber.Text, out parsedValue))
            {
                mvm.ehm.ErrorMessage = errorMessage;
                mvm.ehm.HasErrorMessageRegisterNumber = true;
                return;
            }
            else
                mvm.ehm.HasErrorMessageRegisterNumber = false;


            SetButton();
        }

        private void tbContoNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string errorMessage = "Må ikke indeholde bogstaver!";
            int parsedValue;

            if (!int.TryParse(tbContoNumber.Text, out parsedValue))
            {
                mvm.ehm.ErrorMessage = errorMessage;
                mvm.ehm.HasErrorMessageContoNumber = true;
                return;
            }
            else
                mvm.ehm.HasErrorMessageContoNumber = false;


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
