using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }
        
        public int? ProductCount { get; set; }

        public decimal ProductWeigth{ get; set; }

        public string ProductWeigthType{ get; set; }

        public decimal ProductPrice { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }

        public int CompanyID { get; set; }


        public Company Company { get; set; }
    }
}
