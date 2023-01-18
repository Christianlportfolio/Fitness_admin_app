using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class Member
    {
        public DateTime MemberStartDate { get; set; } 

        public bool Membership { get; set; } 

        public bool Status { get; set; } 

        public string Extras { get; set; } 

        public int CutCart { get; set; } 

        public Member (DateTime memberStartDate, bool membership, bool status, string extras, int cutCart)
        {
            MemberStartDate = memberStartDate;
            Membership = membership;
            Status = status;
            Extras = extras;
            CutCart = cutCart;
        }




    }
}
