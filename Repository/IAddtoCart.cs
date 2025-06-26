using MVCEcommerce.Models.Entities;

namespace MVCEcommerce.Repository
{
    public interface IAddtoCart
    {
        CartItem AddProductsToCart(ProductDetail productDetail, int requestedQty);
    }
}
