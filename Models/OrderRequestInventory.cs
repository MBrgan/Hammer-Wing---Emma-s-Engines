using System.ComponentModel.DataAnnotations;

namespace EmmaProject.Models
{
    public class OrderRequestInventory
    {
        [Display(Name = "Order Request")]
        [Required(ErrorMessage = "Order Request cant be left blank")]
        [DataType(DataType.MultilineText)]
        public int OrderRequestID { get; set; }
        public OrderRequest OrderRequest { get; set; }


        [Display(Name = "UPC")]
        [Required(ErrorMessage = "UPC must match the pattern '###-####-#'")]
        [RegularExpression("^[0-9]{3}-[0-9]{4}-[0 - 9]$", ErrorMessage = "The Postal Code in the format of 'M3A 1A5'")]
        public int UPC_ID { get; set; }
        public Inventory Inventory { get; set; }    
    }
}
