using MVCEcommerce.Models;
using MVCEcommerce.Models.Entities;

namespace MVCEcommerce.Repository
{
    public interface IAddtoCart
    {
        ProductViewModel AddProductsToCart(ProductDetail productDetail, int requestedQty);
        void Delete(int id);
    }
}
