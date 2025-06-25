using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerce.Models.DTO
{
    public class ProductDetailDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public float? PriceOfProduct { get; set; }
        public int availableProduct { get; set; }
        public byte[]? ImageData { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public int CategoryId { get; set; }

    }
}
