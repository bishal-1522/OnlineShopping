using MVCEcommerce.Models.DTO;
using MVCEcommerce.Models.Entities;

namespace MVCEcommerce.Models
{
    public class ProductViewModel
    {
        public ProductDetailDto Product { get; set; }
        public List<ProductCategory> Categories { get; set; }
    }
}
