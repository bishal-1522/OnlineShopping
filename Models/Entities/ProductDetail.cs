using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerce.Models.Entities
{
    public class ProductDetail
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public float ? PriceOfProduct { get; set; }
        public int availableProduct {  get; set; }
        public byte[] ImageData { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public List<ProductCategory>? ProductCategory { get; set; }
        public IFormFile File { get; internal set; }
    }
}
