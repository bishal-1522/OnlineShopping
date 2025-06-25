using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCEcommerce.Models.DTO;
using MVCEcommerce.Models.Entities;
using MVCEcommerce.Repository;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;   
        }
        //product category
        [HttpGet("category")]
        public IEnumerable<ProductCategory> GetAllCategories()
        {
            return productRepository.GetAllCategories();
        }
        [HttpGet("categoryname{categoryName}")]
        public ProductCategory GetCategoryByName(string categoryName)
        {

            return productRepository.GetCategoryByName(categoryName);
        }

        
        [Authorize(Roles = "Admin")]
        [HttpPost("category")]
        public ProductCategory AddCategory(ProductCategoryDto productCategorydto)
        {
            return productRepository.AddCategory(productCategorydto);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("category{id}")]
        public ProductCategory UpdateCategory(ProductCategoryDto productCategory, int id)
        {
            return productRepository.UpdateCategory(productCategory, id);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("category{id}")]
        public ProductCategory DeleteCategory(int id)
        {
            return productRepository.DeleteCategory(id);
        }


        //productdetail
        [HttpGet("product")]
        public IEnumerable<ProductDetail> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }
        [HttpGet("productname{productName}")]
        public IEnumerable<ProductDetail> GetProductByName(string productName)
        {
            return productRepository.GetProductByName(productName);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("product")]
        public ProductDetail AddProduct(ProductDetailDto productDetail)
        {
            return productRepository.AddProduct(productDetail);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("product{id})")]
        public ProductDetail UpdateProduct(ProductDetailDto productDetaildto, int id)
        {
            return productRepository.UpdateProduct(productDetaildto, id);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("product{id}")]
        public ProductDetail DeleteProduct(int id)
        {
            return productRepository.DeleteProduct(id);
        }
    }
}
