using System.ComponentModel.DataAnnotations;

namespace EmmaProject.Models
{
    public class Price
    {
        public int PriceID { get; set; }

        [Display(Name = "UPC")]
        [Required(ErrorMessage = "UPC can't be left blank")]
        [RegularExpression("^[0-9]{3}-[0-9]{4}-[0-9]$", ErrorMessage = "The UPC Code should be in the format '###-####-#'")]
        public string UPC_ID { get; set; }
        public Inventory Inventory { get; set; }

        [Display(Name = "Cost")]
        [Required(ErrorMessage = "You cannot leave Cost blank.")]
        public decimal PricePurchasedCost { get; set; }

        [Display(Name = "Purchased Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "You cannot leave Purchased Date blank.")]
        public DateTime PricePurchasedDate { get; set; }

        [Display(Name = "Price Count")]
        [Required(ErrorMessage = "You cannot leave Price Count blank.")]
        public int PriceCount { get; set; }

        [Display(Name = "Supplier")]
        public int SupID { get; set; }
        public Supplier Supplier { get; set; }
    }
}
