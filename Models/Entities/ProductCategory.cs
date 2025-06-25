using System.ComponentModel.DataAnnotations;

namespace MVCEcommerce.Models.Entities
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string ?CategoryName { get; set; }
        
        public ICollection<ProductDetail> ?ProductDetails { get;set; }
    }
}
