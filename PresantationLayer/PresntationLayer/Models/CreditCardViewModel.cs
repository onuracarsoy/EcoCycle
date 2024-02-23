using System.ComponentModel.DataAnnotations;

namespace PresantationLayer.Models
{
    public class CreditCardViewModel
    {

        public int ProductID { get; set; }
        [Required(ErrorMessage = "CARD NUMBER boş geçilemez.")]
        public int? Number { get; set; }

        [Required(ErrorMessage = "EXPIRY boş geçilemez.")]
        public int? Expiry { get; set; }

        [Required(ErrorMessage = "CVC boş geçilemez.")]
        public int? CVC { get; set; }

        [Required(ErrorMessage = "NAME OF CARD boş geçilemez.")]
        public string nameCard { get; set; }


    }
}
