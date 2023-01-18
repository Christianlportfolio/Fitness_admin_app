using FitnessApp.View;
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

namespace FitnessApp
{
    /// <summary>
    /// Interaction logic for CustomerDialog.xaml
    /// </summary>
    public partial class CreateCustomerDialog : Window
    {

        MainViewModel mvm = new MainViewModel()
        {
            cvm = new CustomerViewModel(),
            ehm = new ErrorHandlingViewModel()
        };

        CustomerController customerController;

        

        public CreateCustomerDialog()
        {
            InitializeComponent();

            DataContext = mvm;
           

            customerController = new CustomerController();

           
        }



        private void btnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {

            try { 

                bool noPhoneNumber = rNoPhoneNumber.IsChecked.Value;

                bool newsletter = false;
                if (cbTrue.IsChecked == true)
                {
                    newsletter = true;
                }
              
                else if (cbFalse.IsChecked == true)
                {
                    newsletter = false;
                }
                
                if (noPhoneNumber == true)
                {
                    customerController.CreateCustomer(tbName.Text, tbCprNumber.Text, int.Parse(cbAge.Text), tbAddress.Text, int.Parse(tbZipCode.Text), tbCity.Text, tbEmail.Text, newsletter);
                }
            
                else
                {
                    customerController.CreateCustomerWithPhoneNumber(tbName.Text, tbCprNumber.Text, int.Parse(cbAge.Text), tbAddress.Text, int.Parse(tbZipCode.Text), tbCity.Text, tbEmail.Text, tbTelephoneNumber.Text, newsletter);
                }

                MessageBoxResult result = MessageBox.Show("Succes! \n\nVil du oprette en ny kunde?", "Bekræftelse", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    CreateCustomerDialog createCustomerDialog = new CreateCustomerDialog();
                    createCustomerDialog.ShowDialog();
                }
                else if(result == MessageBoxResult.No) 
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

            //finally
            //{
            //    CreateCustomerDialog createCustomerDialog = new CreateCustomerDialog();
            //    createCustomerDialog.ShowDialog();
            //}

            this.DialogResult = true;

        }

        public void SetButton()
        {
            btnCreateCustomer.IsEnabled = (tbName.Text != "") && (tbCprNumber.Text != "") && (cbAge.SelectedItem != null) && (tbAddress.Text != "") && (tbZipCode.Text != "") && (tbCity.Text != "") && (tbEmail.Text != "") && (tbTelephoneNumber.Text != "" || rNoPhoneNumber.IsChecked != false) && (cbTrue.IsChecked != false || cbFalse.IsChecked != false);
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void tbCprNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            string errorMessage = "Må ikke indeholde bindestreg!";
            

            if (tbCprNumber.Text.Contains("-"))
            {
                mvm.ehm.ErrorMessage = errorMessage;
                mvm.ehm.HasErrorMessageCprNumber = true;
               
               
            }

            else 
                mvm.ehm.HasErrorMessageCprNumber = false;

            SetButton();
        }

        private void cbAge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButton();
        }

        private void tbAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            string errorMessage = "Må ikke indeholde komma!";
          

            if (tbAddress.Text.Contains(","))
            {
                mvm.ehm.ErrorMessage = errorMessage;
                mvm.ehm.HasErrorMessageAddress = true;
                
       
            }
            else
                mvm.ehm.HasErrorMessageAddress = false;

            SetButton();
        }

        private void tbZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            string errorMessage = "Må ikke indeholde bogstaver!";
            int parsedValue;

            if (!int.TryParse(tbZipCode.Text, out parsedValue))
            {
                mvm.ehm.ErrorMessage = errorMessage;
                mvm.ehm.HasErrorMessageZipCode = true;
                return;
            }
            else
                mvm.ehm.HasErrorMessageZipCode = false;

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
            if (tbTelephoneNumber.Text != "")
                rNoPhoneNumber.IsChecked = false;
            SetButton();
        }

        private void rNoPhoneNumber_Checked(object sender, RoutedEventArgs e)
        {
            if (rNoPhoneNumber.IsChecked == true)
                tbTelephoneNumber.Clear();
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

       
    }
}
