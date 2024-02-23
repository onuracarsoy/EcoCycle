namespace PresantationLayer.Models
{
    public class ResultSalesViewModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int? ProductCount { get; set; }

        public decimal ProductWeigth { get; set; }

        public string ProductWeigthType { get; set; }

        public decimal ProductPrice { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }


        public int CompanyID { get; set; }

        public string CompanyName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string CompanyMail { get; set; }

        public string CompanyPhoneNumber { get; set; }

        public int AppUserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

    }
}
