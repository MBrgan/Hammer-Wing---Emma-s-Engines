using System.ComponentModel.DataAnnotations;

namespace EmmaProject.Models
{
    public class OrderRequestInventory
    {
        [Display(Name = "Order Request")]
        [Required(ErrorMessage = "Order Request can't be left blank")]
        [DataType(DataType.MultilineText)]
        public int OrderRequestID { get; set; }
        public OrderRequest OrderRequest { get; set; }


        [Display(Name = "UPC")]
        [Required(ErrorMessage = "UPC can't be left blank")]
        [RegularExpression("^[0-9]{3}-[0-9]{4}-[0-9]$", ErrorMessage = "The UPC Code should be in the format '###-####-#'")]
        public string UPC_ID { get; set; }
        public Inventory Inventory { get; set; }    
    }
}
