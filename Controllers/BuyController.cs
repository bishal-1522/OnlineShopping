using MVCEcommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCEcommerce.Models.DTO;

namespace MVCEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        private readonly IBuyProductRepo buyProductRepo;

        public BuyController(IBuyProductRepo buyProductRepo)
        {
            this.buyProductRepo = buyProductRepo;
        }

        [Authorize]
        [HttpPost("purchase")]
        public IActionResult MakePurchase([FromBody] AvailabilityDto availabilityDto)
        {
            if (availabilityDto == null || string.IsNullOrWhiteSpace(availabilityDto.ProductName) || availabilityDto.requestedQty <= 0)
            {
                return BadRequest("Invalid product name or quantity.");
            }

            var result = buyProductRepo.MakePurchase(availabilityDto);

            if (result == null)
            {
                return NotFound("Product not found or insufficient quantity.");
            }

            return Ok(new
            {
                status = "OrderCompleted",
                message = $"Order for {availabilityDto.requestedQty} pieces of {result.ProductName} has been completed successfully.",
                orderDetails = new
                {
                    message = "Purchase successful.",
                    remainingStock = result.availableProduct,
                    productId = result.ProductId,
                    productName = result.ProductName,
                    totalprice = result.PriceOfProduct * availabilityDto.requestedQty,
                    paymentMethod = availabilityDto.paymentMethod.ToString(),
                    orderTimestamp = DateTime.UtcNow

                }
            });
        }

    }
}

