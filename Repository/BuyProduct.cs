using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Data;
using MVCEcommerce.Models.Entities;
using System.Data;

namespace MVCEcommerce.Repository
{
    public class BuyProduct :IBuyProduct
    {
        private readonly ProductDbContext productDbContext;
        public BuyProduct(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }
        public int PurchaseProduct(ProductDetail productDetail,int requestedQty)
        {
            int newOrderId = 0;
            if(productDetail.availableProduct>=0)
            {
                if (requestedQty < 0)
                {
                    return 0;
                }
                var total = productDetail.PriceOfProduct * requestedQty;
                var orderDate = DateTime.Now;
                string sql = "exec [dbo].[SpBuyProduct] @productId, @Quantity, @total, @orderDate,@ProductName,@orderId OUT";

                var parameters = new[]
                {
                   new SqlParameter("@productId", productDetail.ProductId),
                   new SqlParameter("@Quantity", requestedQty),
                   new SqlParameter("@total", total),
                   new SqlParameter("@orderDate", orderDate),
                   new SqlParameter("@ProductName", productDetail.ProductName),
                    new SqlParameter("@orderId", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };

                productDbContext.Database.ExecuteSqlRaw(sql, parameters);
                newOrderId = (int)parameters.Last().Value;
                
            }
            return newOrderId;
        }
        public Order GetBill(int id)
        {
            var bill = productDbContext.Orders.FromSqlRaw($"EXEC SPGetBill @orderid={id}").AsEnumerable().FirstOrDefault();
            return bill;
        }
       
    }
}
