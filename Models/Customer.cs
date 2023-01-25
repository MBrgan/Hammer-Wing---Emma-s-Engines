using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmmaProject.Models
{
    public class Customer
    {
        public int CustID { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave Customer First name blank.")]
        [StringLength(50, ErrorMessage = "Customer First name cannot be more than 50 characters long.")]
        public string CustFirst { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters long.")]
        public string CustLast { get; set; }


        [Display(Name = "Phone")]
        public string PhoneFormatted
        {
            get
            {
                return "(" + CustPhone.Substring(0, 3) + ") " + CustPhone.Substring(3, 3) + "-" + CustPhone[6..];
            }
        }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string CustPhone { get; set; }


        [Display(Name = "Address")]
        [Required(ErrorMessage = "You cannot leave Customer Address blank.")]
        [StringLength(100, ErrorMessage = "Customer Address cannot be more than 100 characters long.")]
        public string CustAddress { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "You cannot leave the name of the city blank.")]
        [StringLength(50, ErrorMessage = "City name cannot be more than 50 characters long.")]
        public string CustCity { get; set; }

        [Display(Name = "Province")]
        [Required(ErrorMessage = "You cannot leave the name of the province blank.")]
        [StringLength(2, ErrorMessage = "Province name can only be 2 characters long.")]
        public string CustProvince { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "You cannot leave the Postal Code blank.")]
        [RegularExpression("^[ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[0-9]{1}$", ErrorMessage = "The Postal Code in the format of 'M3A 1A5'")]
        public string CustPostal { get; set; }
       
        [Display(Name = "Invoice")]
        public ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();

        [Display(Name = "Order Request")]
        public ICollection<OrderRequest> OrderRequests { get; set; } = new HashSet<OrderRequest>();
    }
}


