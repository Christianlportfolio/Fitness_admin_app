using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class Membership
    {
        
        public string MembershipType { get; set; }
        

        public DateTime StartDate { get; set; }

        public double CampaignPrice { get; set; }

        public double NormalPrice { get; set; }

        public double CreationPrice { get; set; }

        public Membership (string membershipType, DateTime startDate, double campaignPrice, double normalPrice, double creationPrice)
        {
            MembershipType = membershipType;
            StartDate = startDate;
            CampaignPrice = campaignPrice;
            NormalPrice = normalPrice;
            CreationPrice = creationPrice;
        }



        public override string ToString()
        {
            return $",{MembershipType},{StartDate},{CampaignPrice},{NormalPrice},{CreationPrice}";
        }


    }
}
