using MVCEcommerce.Data;
using MVCEcommerce.Models.DTO;
using MVCEcommerce.Models.Entities;

namespace MVCEcommerce.Repository
{
    public class BuyProductRepository : IBuyProductRepo
    {
        private readonly ProductDbContext productDbContext;
        private readonly ILogger<BuyProductRepository> _logger;
        public BuyProductRepository(ProductDbContext dbContext, ILogger<BuyProductRepository> logger)
        {
            productDbContext = dbContext;
            _logger = logger;
        }
        /*
        public ProductDetail Availability(AvailabilityDto availabilityDto)
        {
            
            if (string.IsNullOrWhiteSpace(availabilityDto?.ProductName) || availabilityDto.requestedQty <= 0)
            {
                 _logger.LogWarning("Invalid product name or requested quantity.");
                return null;
                
            }

            var product = productDbContext.productDetail
                .FirstOrDefault(p => p.ProductName.ToLower() == availabilityDto.ProductName.ToLower());

            if (product == null)
            {
                _logger.LogWarning("Product not found: {ProductName}", availabilityDto.ProductName);
                return null;
            }

            if (product.availableProduct >= availabilityDto.requestedQty)
            {
                _logger.LogInformation("Product '{ProductName}' is available with sufficient quantity: {AvailableQty}",
            product.ProductName, product.availableProduct);
                return new ProductDetail
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    availableProduct = product.availableProduct ,
                    PriceOfProduct = product.PriceOfProduct ?? 0f,
                    CategoryId = product.CategoryId,
                    ProductCategory = product.ProductCategory
                };

            }
           
         _logger.LogWarning("Insufficient quantity for product '{ProductName}'. Requested: {RequestedQty}, Available: {AvailableQty}",
         product.ProductName, availabilityDto.requestedQty, product.availableProduct);

        return product;

        }
            */
        
        public ProductDetail MakePurchase(AvailabilityDto availabilityDto)
        {
            if (availabilityDto == null || string.IsNullOrWhiteSpace(availabilityDto.ProductName) ||availabilityDto.requestedQty <= 0)
            {
                _logger.LogWarning("Invalid purchase request.");
                return null;
            }

            var product = productDbContext.productDetail.FirstOrDefault(p => p.ProductName.ToLower() == availabilityDto.ProductName.ToLower());

            if (product == null)
            {
                _logger.LogWarning("Product not found: {ProductName}", availabilityDto.ProductName);
                return null;
            }

            if (product.availableProduct < availabilityDto.requestedQty)
            {
                _logger.LogWarning("Not enough quantity for product '{ProductName}'. Requested: {Requested}, Available: {Available}",
                    product.ProductName, availabilityDto.requestedQty, product.availableProduct);
                return null;
            }

            
            product.availableProduct -= availabilityDto.requestedQty;
            var order = new Order
            {
                ProductName = product.ProductName,
                Quantity = availabilityDto.requestedQty,
                TotalPrice = (product.PriceOfProduct ?? 0f) * availabilityDto.requestedQty,
                paymentMethod = availabilityDto.paymentMethod
            };
            productDbContext.Add(order);
            productDbContext.SaveChanges();

            _logger.LogInformation("Purchase successful. {Qty} units deducted from '{ProductName}'",
                availabilityDto.requestedQty, product.ProductName);

        

            return product;
        }



    }
    

}
