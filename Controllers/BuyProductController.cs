using Microsoft.AspNetCore.Mvc;
using MVCEcommerce.Models.Entities;
using MVCEcommerce.Repository;

namespace MVCEcommerce.Controllers
{
    public class BuyProductController : Controller
    {
        private readonly IBuyProduct buyProduct;
        public BuyProductController(IBuyProduct buyProduct)
        {
         this.buyProduct = buyProduct;   
        }
        public IActionResult Buy(ProductDetail productDetail, int requestedQty)
        {
            buyProduct.PurchaseProduct(productDetail, requestedQty);
            return View("GetAllProducts");
        }
    }
}
