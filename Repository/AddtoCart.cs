using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Data;
using MVCEcommerce.Models;
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
        public ProductViewModel AddProductsToCart(ProductDetail productDetail, int requestedQty)
        {
            
            var existingCartItem = _dbContext.CartItems.FirstOrDefault(c => c.ProductId == productDetail.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += requestedQty;
            }
            else
            {
                existingCartItem = new CartItem()
                {
                    ProductId = productDetail.ProductId,
                    Quantity = requestedQty,
                 
                    
                };
                _dbContext.CartItems.Add(existingCartItem);
            }

            _dbContext.SaveChanges();
            var productViewModel = new ProductViewModel
            {
                ProductDetail = productDetail,
                CartItem = existingCartItem
            };
            return productViewModel;
        }
        public void Delete(int id) 
        {
            var exisitngitem = _dbContext.CartItems.Find(id);
            if (exisitngitem == null)
            {
                throw new Exception("null");
            }
            _dbContext.Remove(exisitngitem);
            _dbContext.SaveChanges();

        }

    }
}
