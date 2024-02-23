using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.ProductDto
{
    public class ProductEditDto
    {

        public int  ProductID { get; set; }

        public string ProductName { get; set; }

        public int ProductCount { get; set; }

        public decimal ProductPrice { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }

        public int CompanyID { get; set; }
    }
}
