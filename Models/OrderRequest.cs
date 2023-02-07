using System.ComponentModel.DataAnnotations;

namespace EmmaProject.Models
{
    public class OrderRequest
    {
        public int OrderRequestID { get; set; }
      

        [Display(Name = "Customer")]
        [Required(ErrorMessage = "You cannot leave Customer blank")]
        public int CustID { get; set; }
        public Customer Customer { get; set; }

        [Display(Name = "Order Request Desc")]
        [Required(ErrorMessage = "You can not leave Order Request Desc name blank.")]
        [StringLength(500, ErrorMessage = "Order Request Description cannot be more than 500 characters long.")]
        public string ORequestDesc { get; set; }

        [Required(ErrorMessage = "You cannot leave the Order Request Send Date blank.")]
        [Display(Name = "Order Request Send Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly  OReqSendData { get; set; }

        [Required(ErrorMessage = "You cannot leave the Order Request Recive Date blank.")]
        [Display(Name = "Order Request Recive Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly OReqReciveData { get; set; }

        [Display(Name = "External Order Num")]
        [Required(ErrorMessage = "You cannot leave External Order Num blank")]
        [StringLength(20, ErrorMessage = "External Order Num cannot be more than 20 characters long.")]
        public string ExternalOrderNum { get; set; }

        [Display(Name = "Order Request Inventory")]
        public ICollection<OrderRequestInventory> OrderRequestInventories { get; set; } = new HashSet<OrderRequestInventory>();
    }
}
