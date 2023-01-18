using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.ViewModel
{
    public class MembershipController
    {

        private CustomerRepository customerRepository;

        private MembershipRepository membershipRepository;

        public MembershipController()
        {
            customerRepository = new CustomerRepository();
            membershipRepository = new MembershipRepository();
        }

        public void CreateMembership(int id, string membershipType, DateTime startDate, double campaignPrice, double normalPrice, double creationPrice)
        {
            Customer selectedCustomer = customerRepository.GetCompanyByID(id);
            Membership membership = new Membership(membershipType, startDate, campaignPrice, normalPrice, creationPrice);
            membershipRepository.AddMembership(selectedCustomer, membership);
        }




    }
}
