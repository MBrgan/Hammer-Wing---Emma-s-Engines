using System.ComponentModel.DataAnnotations;

namespace EmmaProject.Models
{
    public class InvoiceLine
    {

        

        [Display(Name = "Invoice")]
        [Required(ErrorMessage = "You cannot leave Invoice blank")]
        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }


        [Display(Name = "UPC")]
        [Required(ErrorMessage = "UPC must match the pattern '###-####-#'")]
        [RegularExpression("^[0-9]{3}-[0-9]{4}-[0 - 9]$", ErrorMessage = "The Postal Code in the format of 'M3A 1A5'")]
        public int UPC_ID { get; set; }
        public Inventory Inventory { get; set; }


        [Display(Name = "Quanity")]
        [Required(ErrorMessage = "Quanity Requied")]
        public int OtQuanity { get; set; }

        [Display(Name = "Sale Price")]
        [Required(ErrorMessage = "Sale Price Requied")]
        public decimal OtSalePrice { get; set; }
    }
}
