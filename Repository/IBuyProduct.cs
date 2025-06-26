using MVCEcommerce.Models.Entities;

namespace MVCEcommerce.Repository
{
    public interface IBuyProduct
    {
        void PurchaseProduct(ProductDetail productDetail, int requestedQty);
    }
}
