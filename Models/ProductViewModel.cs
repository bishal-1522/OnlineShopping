using MVCEcommerce.Models.DTO;
using MVCEcommerce.Models.Entities;

namespace MVCEcommerce.Models
{
    public class ProductViewModel
    {
        public ProductDetail ProductDetail { get; set; }
        public ProductDetailDto Product { get; set; }
        public List<ProductCategory> Categories { get; set; }
        public ProductCategory Category { get; set; }
        public CartItem CartItem { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
