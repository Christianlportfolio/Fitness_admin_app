using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace FitnessApp.ViewModel
{
    public class MembershipViewModel : INotifyPropertyChanged
    {

        public CustomerRepository customerRepository;

        public string[] MembershipType { get; set; }

        public List<Customer> Customers { get; set; }

        public List<object> CustomersToAddMembership { get; set; }


        public MembershipRepository membershipRepository;
        public List<object> objectList { get; set; }

        private List<Membership> memberships { get; set; }


        private Customer selectedCostumer;

        public Customer SelectedCostumer
        {
            get { return selectedCostumer; }

            set
            {
                if (selectedCostumer != value)
                {
                    selectedCostumer = value;
                    OnPropertyChanged("SelectedCostumer");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }




        public MembershipViewModel()
        {

            MembershipType = new string[] { "Premium", "Standard", "Basic" };

            customerRepository = new CustomerRepository();
            Customers = customerRepository.GetAllCustomers();

            membershipRepository = new MembershipRepository();
            objectList = membershipRepository.GetAllObjects();
            memberships = membershipRepository.GetAllMemberships();


            CustomersToAddMembership = new List<object>();


            var customerAndMemberships = Customers.Zip(objectList, (c, o) => new { Customers = c, objectList = o });


            foreach (Customer customer in Customers)
            {
                CustomersToAddMembership.Add(customer);
            }

            
            //foreach (var co in customerAndMemberships)
            //{

            //    var uniqueItems1 = Customers.Distinct();
            //    var uniqueItems2 = objectList.Distinct();

            //    if(!objectList.Contains(uniqueItems1) && !objectList.Contains(uniqueItems2))
            //    {
            //        CustomersToAddMembership.Add(co.Customers);
            //    }
                



            //}

           
            
            
            
            
            
            //foreach (object customer in objectList)
            //{
            //    CustomersToAddMembership.Add(customer);
            //}







        }







    }


    
}
