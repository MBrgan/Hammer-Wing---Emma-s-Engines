using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmmaProject.Models
{
    public class Position
    {
        public int PosID { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "You cannot leave the employee title blank.")]
        [StringLength(50, ErrorMessage = "The employee title cannot be more than 50 characters long.")]
        public string PosTitle { get; set; }

        [Display(Name = "Employee Position")]
        public ICollection<EmployeePosition> EmployeePositions { get; set; } = new HashSet<EmployeePosition>();
      
    }
}
