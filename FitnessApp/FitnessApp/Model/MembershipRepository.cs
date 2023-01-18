using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class MembershipRepository
    {




       


        private List<Membership> memberships;

        private List<object> objectList;

        CustomerRepository customerRepository;

   



        public List<Customer> Customers { get; }

        private string fileName;
        
        
        public MembershipRepository()
        {
            memberships = new List<Membership>();

            customerRepository = new CustomerRepository();

            Customers = customerRepository.GetAllCustomers();

            objectList = Customers.Cast<object>()
               .Concat(memberships)
               .ToList();


            int idCount = 0;
            fileName = "memberships.txt";
            if (File.Exists(fileName))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        while (sr.EndOfStream != true)
                        {
                            string[] customerAttributes = new string[18];
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
                            string membershipType = customerAttributes[13];
                            DateTime startDate = DateTime.Parse(customerAttributes[14]);
                            double campaignPrice = double.Parse(customerAttributes[15]);
                            double normalPrice = double.Parse(customerAttributes[16]);
                            double creationPrice = double.Parse(customerAttributes[17]);

                            Customer customer = new Customer(name, cprNumber, age, address, zipCode, city, email, phoneNumber, newsletter, registerNumber, contoNumber, membershipCondition, consent);
                            Membership membership = new Membership(membershipType, startDate, campaignPrice, normalPrice, creationPrice);
                           
                            customer.ID = idCount++;
                            objectList.Add(customer);
                            objectList.Add(membership);
                        }

                    }

                }

                catch (IOException)
                {
                    throw;
                }
            }





        }












            public void AddMembership(Customer customer, Membership membership)
        {


            //List<object> objectList = Customers.Cast<object>()
            //   .Concat(memberships)
            //   .ToList();

            objectList.Add(customer);
            objectList.Add(membership);

            fileName = "memberships.txt";
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.Write(customer.ToString());
                sw.WriteLine(membership.ToString());
            }


        }

       














        public List<Membership> GetAllMemberships()
        {
            return memberships;
        }

        public List<object> GetAllObjects()
        {
            return objectList;
        }




    }
}
