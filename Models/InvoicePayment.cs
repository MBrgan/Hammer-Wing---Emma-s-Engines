using System.ComponentModel.DataAnnotations;

namespace EmmaProject.Models
{
    public class InvoicePayment
    {
        [Display(Name = "Invoice")]
        [Required(ErrorMessage = "You cannot leave Invoice blank")]
        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        [Display(Name = "Invoice")]
        [Required(ErrorMessage = "You cannot leave Payment blank")]
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
    }
}
