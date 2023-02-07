using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmmaProject.Models
{
    public class Position
    {
        public int PosID { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "You cannot leave Employee Title blank.")]
        [StringLength(50, ErrorMessage = "Employee Title cannot be more than 50 characters long.")]
        public string PosTitle { get; set; }

        [Display(Name = "Emp Position")]
        public ICollection<EmployeePosition> EmployeePositions { get; set; } = new HashSet<EmployeePosition>();
      
    }
}
