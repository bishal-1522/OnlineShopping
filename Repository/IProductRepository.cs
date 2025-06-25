using MVCEcommerce.Models.DTO;
using MVCEcommerce.Models.Entities;

namespace MVCEcommerce.Repository
{
    public interface IProductRepository 
    {
        //product category
        public IEnumerable<ProductCategory> GetAllCategories();
        public ProductCategory GetCategoryByName(string categoryName);
        public ProductCategory AddCategory(ProductCategoryDto productCategorydto);
        public ProductCategory UpdateCategory(ProductCategoryDto productCategorydto, int id);
        public ProductCategory DeleteCategory(int id);

        //product detail
        public IEnumerable<ProductDetail> GetAllProducts();
        IEnumerable<ProductDetail> GetProductByName(string productName);
        IEnumerable<ProductDetail> GetProductById(int id);
        public ProductDetail AddProduct(ProductDetailDto productDetaildto);
        public ProductDetail UpdateProduct(ProductDetailDto productDetaildto, int id);
        public ProductDetail DeleteProduct(int id);

        

    }
}
