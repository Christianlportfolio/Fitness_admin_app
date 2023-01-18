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
    /// Interaction logic for CreateMembershipDialog.xaml
    /// </summary>
    public partial class CreateMembershipDialog : Window
    {

        MainViewModel mvm = new MainViewModel()
        {
            cvm = new CustomerViewModel(),
            ehm = new ErrorHandlingViewModel(),
            msvm = new MembershipViewModel()
        };

        CustomerController customerController;
        MembershipController membershipController;
        


        public CreateMembershipDialog()
        {
            InitializeComponent();

            DataContext = mvm;

            customerController = new CustomerController();
            membershipController = new MembershipController();

            


    }

        private void cbMembershipType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbMembershipType.SelectedItem.ToString() == "Premium")
            {
                tbCampaignPrice.Text = "299.95";
                tbNormalPrice.Text = "399.95";
                tbCreationPrice.Text = "0.00";
            }
               

            else if (cbMembershipType.SelectedItem.ToString() == "Standard")
            {
                tbCampaignPrice.Text = "199.95";
                tbNormalPrice.Text = "299.95";
                tbCreationPrice.Text = "50.00";
            }
               
            else if (cbMembershipType.SelectedItem.ToString() == "Basic")
            {
                tbCampaignPrice.Text = "99.95";
                tbNormalPrice.Text = "199.95";
                tbCreationPrice.Text = "100.00";
            }
                
        }

        private void btnCreateMembership_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = lbCustomer.SelectedItem as Customer;

            

            if(lbCustomer.SelectedItem != null)
            {
                membershipController.CreateMembership(customer.ID, cbMembershipType.Text, dpStartDate.SelectedDate.Value, double.Parse(tbCampaignPrice.Text), double.Parse(tbNormalPrice.Text), double.Parse(tbCreationPrice.Text));
            }

          
            
            this.DialogResult = true;


          

        }

       
    }
}
