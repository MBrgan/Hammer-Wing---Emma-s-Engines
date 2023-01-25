using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace EmmaProject.Models
{
    public class EmployeePosition
    {
        [Display(Name = "Employee")]
        [Required(ErrorMessage = "You cannot leave Employee blank")]
        public int EmpID { get; set; }
        public Employee Employee { get; set; }

        [Display(Name = "Position")]
        [Required(ErrorMessage = "You cannot leave Position blank")]
        public string PosID { get; set; }
        public Position Position { get; set; }



    }
}
