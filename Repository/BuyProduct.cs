using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Data;
using MVCEcommerce.Models.Entities;

namespace MVCEcommerce.Repository
{
    public class BuyProduct :IBuyProduct
    {
        private readonly ProductDbContext productDbContext;
        public BuyProduct(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }
        public void PurchaseProduct(ProductDetail productDetail,int requestedQty)
        {
            if(productDetail.availableProduct>=0)
            {
                var total = productDetail.PriceOfProduct * requestedQty;
                var orderDate = DateTime.UtcNow;
                string sql = "exec [dbo].[SpBuyProduct] @productId, @Quantity, @total, @orderDate";

                var parameters = new[]
                {
                   new SqlParameter("@productId", productDetail.ProductId),
                   new SqlParameter("@Quantity", requestedQty),
                   new SqlParameter("@total", total),
                   new SqlParameter("@orderDate", orderDate)
                };

                productDbContext.Database.ExecuteSqlRaw(sql, parameters);
            }
          

        }
    }
}
