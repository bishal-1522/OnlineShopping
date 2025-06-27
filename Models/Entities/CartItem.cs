using System.ComponentModel.DataAnnotations;

namespace MVCEcommerce.Models.Entities
{
    public class CartItem
    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity {  get; set; }

    }
}
