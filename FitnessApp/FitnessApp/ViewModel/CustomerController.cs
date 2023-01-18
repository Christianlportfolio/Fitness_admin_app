using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.ViewModel
{
   
   public class CustomerController
    {
        private CustomerRepository customerRepository;

        public CustomerController()
        {
            customerRepository = new CustomerRepository();
        }
        
        public void CreateCustomer(string name, string cprNumber, int age, string address, int zipCode, string city, string email, bool newsletter)
        {
            Customer customer = new Customer(name, cprNumber, age, address, zipCode, city, email, newsletter);
            customer.PhoneNumber = "ingen";
            customerRepository.AddCustomer(customer);
        }

        public void CreateCustomerWithPhoneNumber(string name, string cprNumber, int age, string address, int zipCode, string city, string email, string phoneNumber, bool newsletter) 
        { 
            Customer customer = new Customer(name, cprNumber, age, address, zipCode, city, email, phoneNumber, newsletter);
            customer.PhoneNumber = phoneNumber;
            customerRepository.AddCustomer(customer);
        }

        public void AddPaymentInformation(int id, int registerNumber, long contoNumber, bool membershipCondition, bool consent)
        {
            Customer selectedCustomer = customerRepository.GetCompanyByID(id);
            customerRepository.AddPaymentInformation(selectedCustomer, registerNumber, contoNumber, membershipCondition, consent);
        }

        public void UpdateSelectedCustomer(int id, string name, string cprNumber, int age, string address, int zipCode, string city, string email, string phoneNumber, bool newsletter, int registerNumber, long contoNumber, bool membershipCondition, bool consent)
        {
            Customer selectedCustomer = customerRepository.GetCompanyByID(id);
            customerRepository.UpdateCustomer(selectedCustomer, name, cprNumber, age, address, zipCode, city, email, phoneNumber, newsletter, registerNumber, contoNumber, membershipCondition, consent);
        }
      
        public void DeleteSelectedCustomer(int id)
        {
            Customer selectedCustomer = customerRepository.GetCompanyByID(id);
            customerRepository.DeleteCustomer(selectedCustomer);
        }

    }
}
