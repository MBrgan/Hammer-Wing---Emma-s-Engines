using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace EmmaProject.Models
{
    public class EmpLogin
    {
        public int LogID { get; set; }

        [Display(Name = "Sign In")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SignIn { get; set; }

        [Display(Name = "Sign Out")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SignOut { get; set; }


        [Display(Name = "Employee")]
        public int EmpID { get; set; }
        public Employee Employee { get; set; }

    }
}
