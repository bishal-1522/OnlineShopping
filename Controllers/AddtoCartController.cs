using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Data;
using MVCEcommerce.Models.Entities;
using MVCEcommerce.Repository;

namespace MVCEcommerce.Controllers
{
    public class AddtoCartController : Controller
    {
        private readonly IAddtoCart cart;
        private readonly ProductDbContext _dbContext;
        public AddtoCartController(IAddtoCart addtoCart,ProductDbContext productDbContext)
        {
            this.cart = addtoCart;
            this._dbContext = productDbContext;
        }
        [HttpGet]
        public IActionResult GetAddtoCart() 
        {
            return View("AddtoCart");
        }

        [HttpPost]
        public IActionResult Addcart(int productId, int requestedQty)
        {
            var product = _dbContext.productDetail.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            var cartItem = cart.AddProductsToCart(product, requestedQty);
            return View("Addtocart", cartItem); 
        }
        [HttpPost]
        public IActionResult Delete(int cartId)
        {
            cart.Delete(cartId);
            return RedirectToAction("GetAllProducts","Products");

        }
    }
}
