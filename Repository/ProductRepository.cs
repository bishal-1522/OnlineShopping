using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Data;
using MVCEcommerce.Models.DTO;
using MVCEcommerce.Models.Entities;
using System;

namespace MVCEcommerce.Repository
{
    public class ProductRepository :IProductRepository
    {
        private readonly ProductDbContext productDbContext;
        public ProductRepository(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }
        //category 
        public IEnumerable<ProductCategory> GetAllCategories()
        {
            return productDbContext.productCategory.ToList();
        }
        public ProductCategory GetCategoryByName(string categoryName)
        {
            return productDbContext.productCategory.FirstOrDefault(name => name.CategoryName.Equals(categoryName));
        }
        public ProductCategory AddCategory(ProductCategoryDto productCategorydto)
        {
            var productEntity = new ProductCategory()
            {
                 CategoryName= productCategorydto.CategoryName,
       
            };

            productDbContext.productCategory.Add(productEntity);
            productDbContext.SaveChanges();

            return productEntity;
        }
        
        public ProductCategory UpdateCategory(ProductCategoryDto productCategorydto, int id)
        {
            var exisitingCategory=productDbContext.productCategory.Find( id);
            if (exisitingCategory==null)
            {
                return null;
            }
            
           
            exisitingCategory.CategoryName = productCategorydto.CategoryName;
            productDbContext.SaveChanges();
            return exisitingCategory;
        }
        public ProductCategory DeleteCategory(int id)
        {
            var existing=productDbContext.productCategory.Find(id);
            if (existing == null)
            {
                return null;
            }
            productDbContext.productCategory.Remove(existing);
            productDbContext.SaveChanges();
            return existing;

        }




        //product detail
        public IEnumerable<ProductDetail> GetAllProducts()
        {
            return productDbContext.productDetail.ToList();
        }
        public IEnumerable<ProductDetail> GetProductByName(string productName)
        {
            return productDbContext.productDetail.Where(name => name.ProductName.Equals(productName)).ToList();
        }
        public ProductDetail GetProductById(int id)
        {
            return productDbContext.productDetail.FirstOrDefault(p => p.ProductId == id);
        }
        public ProductDetail AddProduct(ProductDetailDto productDetailDto)
        {
            byte[] imageData = null;
            string imageName = null;
            string contentType = null;

            if (productDetailDto.ImageFile != null && productDetailDto.ImageFile.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                productDetailDto.ImageFile.CopyTo(memoryStream);
                imageData = memoryStream.ToArray();
                imageName = productDetailDto.ImageFile.FileName;
                contentType = productDetailDto.ImageFile.ContentType;
            }


            var productEntity = new ProductDetail
            {
                ProductName = productDetailDto.ProductName,
                PriceOfProduct = productDetailDto.PriceOfProduct,
                availableProduct = productDetailDto.availableProduct,
                CategoryId = productDetailDto.CategoryId,
                ImageData = imageData, 
               
            };

            productDbContext.productDetail.Add(productEntity);
            
            productDbContext.SaveChanges();

            return productEntity;
        }

        public ProductDetail UpdateProduct(ProductDetailDto productDetaildto, int id)
        {
            var existingProduct = productDbContext.productDetail.Find(id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.ProductName = productDetaildto.ProductName;
            existingProduct.PriceOfProduct = productDetaildto.PriceOfProduct;
            productDbContext.SaveChanges();
            return existingProduct;
        }
        public IEnumerable<ProductDetail> SortListing( string name)
        {
            

            var products = productDbContext.productDetail
                .FromSqlRaw($"EXEC SortingMatchingByNames @search={name}")
                .ToList();

            return products;
        }
        public ProductDetail DeleteProduct(int id)
        {
            var prodDel = productDbContext.productDetail.Find(id);
            if (prodDel == null)
            {
                return null;
            }
            productDbContext.productDetail.Remove(prodDel);
            productDbContext.SaveChanges();
            return prodDel;
        }

      
    }
}
