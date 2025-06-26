using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Data;
using MVCEcommerce.Models.Entities;
using System.Data;

namespace MVCEcommerce.Repository
{
    public class AddtoCart :IAddtoCart
    {
        private readonly ProductDbContext _dbContext;
        public AddtoCart( ProductDbContext productDbContext)
        {
            this._dbContext = productDbContext;
        }
        public CartItem AddProductsToCart(ProductDetail productDetail,int requestedQty) 
        {
            var cart = new CartItem()
            {
                ProductId= productDetail.ProductId,
                Quantity= requestedQty
            };
            _dbContext.CartItems.Add(cart);
            _dbContext.SaveChanges();
            return cart;
        }
    }
}
