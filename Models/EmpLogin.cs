using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace EmmaProject.Models
{
    public class EmpLogin
    {
        public int LogID { get; set; }

        [Display(Name = "SinIn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SinIn { get; set; }

        [Display(Name = "SinOut")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SinOut { get; set; }


        [Display(Name = "Employee")]
        public int EmpID { get; set; }
        public Employee Employee { get; set; }

    }
}
