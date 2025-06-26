using MVCEcommerce.Models.Entities;

namespace MVCEcommerce.Repository
{
    public interface IBuyProduct
    {
        int PurchaseProduct(ProductDetail productDetail, int requestedQty);
        Order GetBill(int id);
    }
}
