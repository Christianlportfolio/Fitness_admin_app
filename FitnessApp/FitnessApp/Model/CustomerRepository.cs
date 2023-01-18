using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FitnessApp.Model
{
    public class CustomerRepository
    {

        private List<Customer> customers;
        

        private string fileName;
        public CustomerRepository()
        {
            customers = new List<Customer>();


            int idCount = 0;
            fileName = "Customer.txt";
            if (File.Exists(fileName))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        while (sr.EndOfStream != true)
                        {
                            string[] customerAttributes = new string[13];
                            customerAttributes = sr.ReadLine().Split(',');
                            string name = customerAttributes[0];
                            string cprNumber = customerAttributes[1];
                            int age = int.Parse(customerAttributes[2]);
                            string address = customerAttributes[3];
                            int zipCode = int.Parse(customerAttributes[4]);
                            string city = customerAttributes[5];
                            string email = customerAttributes[6];
                            string phoneNumber = customerAttributes[7];
                            bool newsletter = bool.Parse(customerAttributes[8]);
                            int registerNumber = int.Parse(customerAttributes[9]);
                            long contoNumber = long.Parse(customerAttributes[10]);
                            bool membershipCondition = bool.Parse(customerAttributes[11]);
                            bool consent = bool.Parse(customerAttributes[12]);

                            Customer customer = new Customer(name, cprNumber, age, address, zipCode, city, email, phoneNumber, newsletter, registerNumber, contoNumber, membershipCondition, consent);
                            customer.ID = idCount++;
                            customers.Add(customer);
                        }

                    }

                }

                catch (IOException)
                {
                    throw;
                }
            }




        }

    
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);

            fileName = "Customer.txt";
            WriteToFile(fileName);

        }

        public void DeleteCustomer(Customer customer)
        {
            customers.Remove(customer);

            fileName = "Customer.txt";
            WriteToFile(fileName);
        
        
        
        
        }

        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public Customer GetCompanyByID(int id)
        {
            foreach (Customer customer in customers)
            {
                if (customer.ID == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public void AddPaymentInformation(Customer customer, int registerNumber, long contoNumber, bool membershipCondition, bool consent )
        {
            customer.RegisterNumber = registerNumber;
            customer.ContoNumber = contoNumber;
            customer.MembershipCondition = membershipCondition;
            customer.Consent = consent;

            fileName = "Customer.txt";
            WriteToFile(fileName);
        }

        public void UpdateCustomer(Customer customer, string name, string cprNumber, int age, string address, int zipCode, string city, string email, string phoneNumber, bool newsletter, int registerNumber, long contoNumber, bool membershipCondition, bool consent)
        {
            if (customer.Name != name)
                customer.Name = name;
            if (customer.CprNumber != cprNumber)
                customer.CprNumber = cprNumber;
            if (customer.Age != age)
                customer.Age = age;
            if (customer.Address != address)
                customer.Address = address;
            if (customer.ZipCode != zipCode)
                customer.ZipCode = zipCode;
            if (customer.City != city)
                customer.City = city;
            if (customer.Email != email)
                customer.Email = email;
            if (customer.PhoneNumber != phoneNumber)
                customer.PhoneNumber = phoneNumber;
            if (customer.Newsletter != newsletter)
                customer.Newsletter = newsletter;
            if (customer.RegisterNumber != registerNumber)
                customer.RegisterNumber = registerNumber;
            if (customer.ContoNumber != contoNumber)
                customer.ContoNumber = contoNumber;
            if (customer.MembershipCondition != membershipCondition)
                customer.MembershipCondition = membershipCondition;
            if (customer.Consent != consent)
                customer.Consent = consent;

            fileName = "Customer.txt";
            WriteToFile(fileName);

        }


        public void WriteToFile(string fileName)
        {
            File.Delete(fileName);
           using(StreamWriter sw = new StreamWriter(fileName, true))
            {
                foreach (Customer customer in customers)
                {
                    sw.WriteLine(customer.ToString());
                }
            }

        }







    }
}
