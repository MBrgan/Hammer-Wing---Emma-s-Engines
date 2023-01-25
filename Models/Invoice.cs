using System.ComponentModel.DataAnnotations;

namespace EmmaProject.Models
{
    public class Invoice
    {


     public int InvoiceID { get; set; }

     public InvoiceLine InvoiceLine { get; set; }

         [Display(Name = "Invoice Date")]
         [DataType(DataType.Date)]
         [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
         public DateOnly InvoiceDate { get; set; }

         [Display(Name = "Appreciation")]
         public decimal Appreciation { get; set; }

        [Display(Name = "Description")]
        [StringLength(50, ErrorMessage = "Description name cannot be more than 50 characters long.")]
        public string Description { get; set; }


        [Display(Name = "Invoice Subtotal")]
        [Required(ErrorMessage = "You cannot leave Invoice Subtotal blank.")]
        public decimal InvoiceSubtotal { get; set; }
   
        [Display(Name = "Customer")]
        [Required(ErrorMessage = "You cannot leave Customer ID blank.")]
         public int CustID { get; set; }
         public Customer Customer { get; set; }

        [Display(Name = "Employee")]
        [Required(ErrorMessage = "You cannot leave Employee ID blank.")]
        public int EmpID { get; set; }
        public Employee Employee { get; set; }

        [Display(Name = "Invoice Payment")]
         public ICollection<InvoicePayment> InvoicePayments { get; set; } = new HashSet<InvoicePayment>();
        }
}
