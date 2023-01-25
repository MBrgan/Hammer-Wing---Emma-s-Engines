using System.ComponentModel.DataAnnotations;

namespace EmmaProject.Models
{
    public class Price
    {
        public int PriceID { get; set; }

        [Display(Name = "UPC")]
        [Required(ErrorMessage = "UPC must match the pattern '###-####-#'")]
        public int UPC_ID { get; set; }
        public Inventory Inventory { get; set; }

        [Display(Name = "Cost")]
        [Required(ErrorMessage = "You cannot leave Cost blank.")]
        public decimal PricePurchasedCost { get; set; }

        [Display(Name = "Purchased Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "You cannot leave Purchased Date blank.")]
        public DateOnly PricePurchasedDate { get; set; }


        [Display(Name = "Price Count")]
        [Required(ErrorMessage = "You cannot leave Price Count blank.")]
        public int PriceCount { get; set; }

        [Display(Name = "Supplier")]
        public int SupID { get; set; }
        public Supplier Supplier { get; set; }
        


    }
}
