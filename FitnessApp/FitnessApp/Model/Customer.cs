using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class Customer
    {
        public string Name { get; set; }
        public string CprNumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        
        public string City { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Newsletter { get; set; }

        public int RegisterNumber { get; set; }

        public long ContoNumber { get; set; }

        public bool MembershipCondition { get; set; }

        public bool Consent { get; set; }

        public int ID { get; set; }

        public Customer(string name, string cprNumber, int age, string address, int zipCode, string city, string email, bool newsletter)
        {
            Name = name;
            CprNumber = cprNumber;
            Age = age;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Email = email;
            Newsletter = newsletter;
        }

        public Customer(string name, string cprNumber, int age, string address, int zipCode, string city, string email, string phoneNumber, bool newsletter):
            this(name, cprNumber, age, address, zipCode,city, email, newsletter)
        { 
            PhoneNumber = phoneNumber;
        }

        public Customer(string name, string cprNumber, int age, string address, int zipCode, string city, string email, string phoneNumber, bool newsletter, int registerNumber, long contoNumber, bool membershipCondition, bool consent):
            this(name, cprNumber, age, address, zipCode, city, email, phoneNumber, newsletter)
        {
            RegisterNumber = registerNumber;
            ContoNumber = contoNumber;
            MembershipCondition = membershipCondition;
            Consent = consent;
        }



        public override string ToString()
        {
            return $"{Name},{CprNumber},{Age},{Address},{ZipCode},{City},{Email},{PhoneNumber},{Newsletter},{RegisterNumber},{ContoNumber},{MembershipCondition},{Consent}";
        }






    }
}
