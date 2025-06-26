using Microsoft.AspNetCore.Mvc;
using MVCEcommerce.Models.Entities;
using MVCEcommerce.Repository;

namespace MVCEcommerce.Controllers
{
    public class AddtoCartController : Controller
    {
        private readonly IAddtoCart cart;
        public AddtoCartController(IAddtoCart addtoCart)
        {
            this.cart = addtoCart;
        }
        public IActionResult Addcart(ProductDetail productDetail,int requestedQty)
        {
            cart.AddProductsToCart(productDetail, requestedQty);
            return View("Addtocart");
        }
    }
}
