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
            int orderId=buyProduct.PurchaseProduct(productDetail, requestedQty);
             var bill=Bill(orderId);
            return View("Bill",bill);
        }
        public Order Bill(int orderId)
        {
           var orderbill= buyProduct.GetBill(orderId);
            return orderbill;
        }
    }
}
