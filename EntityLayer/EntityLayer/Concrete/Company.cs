using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Company
    {
        public int CompanyID { get; set; }

        public string CompanyName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string CompanyMail { get; set; }

        public string CompanyPhoneNumber { get; set; }

        public int AppUserID { get; set; }


        public AppUser AppUser { get; set; }
    }
}
