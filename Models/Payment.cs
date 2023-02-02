using System.ComponentModel.DataAnnotations;

namespace EmmaProject.Models
{
    public class Payment
    {
     public int PaymentID { get; set; }


    [Display(Name = "Payment Type")]
    [Required(ErrorMessage = "You cannot leave the payment type blank.")]
    [StringLength(20, ErrorMessage = "Customer Address cannot be more than 20 characters long.")]
    public string PaymentType { get; set; }
 
    [Required(ErrorMessage = "You cannot leave the notes blank.")]
    [StringLength(500, ErrorMessage = "Only 500 characters for notes.")]
    [DataType(DataType.MultilineText)]
    public string OtherDescription { get; set; }


    [Display(Name = "Invoice Payments")]
    public ICollection<InvoicePayment> InvoicePayments { get; set; } = new HashSet<InvoicePayment>();
    }
}

