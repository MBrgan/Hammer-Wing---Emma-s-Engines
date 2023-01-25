using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmmaProject.Models
{
    public class Employee
    {
        public int EmpID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string EmpFirst { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters long.")]
        public string EmpLast { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter your username.")]
        public string EmpUserName { get; set; }


        [Required(ErrorMessageResourceName = "Password Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string EmpPassword { get; set; }

        [Display(Name = "Login")]
        public ICollection<EmpLogin> EmpLogins { get; set; } = new HashSet<EmpLogin>();

        [Display(Name = "Position")]
        public ICollection<EmployeePosition> EmployeePositions { get; set; } = new HashSet<EmployeePosition>();
       
        [Display(Name = "Invoice")]
        public ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
    }
}
