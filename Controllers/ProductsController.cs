using Microsoft.AspNetCore.Mvc;
using MVCEcommerce.Models;
using MVCEcommerce.Models.DTO;
using MVCEcommerce.Models.Entities;
using MVCEcommerce.Repository;

namespace MVCEcommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult GetAllProducts()
        {
             var all=productRepository.GetAllProducts();
            return View("~/Views/Products/GetAllProducts.cshtml", all);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            var viewmodel = new ProductViewModel()
            {
                Product = new ProductDetailDto(),
                Categories=productRepository.GetAllCategories().ToList()
            };
            return View("Productadditonform",viewmodel);
        }
        [HttpGet]
        public IActionResult GetProductByProductId(int id) 
        {
            var prod=productRepository.GetProductById(id);
            return View("BuyProduct",prod);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel productViewModel)
        {
            if (productViewModel == null)
            {
                
            }

            var dto = new ProductDetailDto
            {
                ProductName = productViewModel.Product.ProductName,
                PriceOfProduct = productViewModel.Product.PriceOfProduct,
                availableProduct = productViewModel.Product.availableProduct,
                CategoryId = productViewModel.Product.CategoryId, 
                ImageFile=productViewModel.Product.ImageFile,
            };

            var savedEntity= productRepository.AddProduct(dto);
        
            return RedirectToAction("GetAllProducts");
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
             var categories=productRepository.GetAllCategories();
            var viewModel = new ProductViewModel
            {
              Categories = categories.ToList()
               
            };
            return View("GetAllCategories",viewModel);
        }
        [HttpGet]
        public IActionResult GetCategoryByName(string categoryName)
        {
            var categories=productRepository.GetCategoryByName(categoryName);
            var viewmodel = new ProductViewModel()
            {
                Categories = categories!= null ? new List<ProductCategory> { categories } : new List<ProductCategory>()
            };
            return View("GetAllCategories",viewmodel);
        }
        [HttpGet]
        public IActionResult GetProductByName(string productName)
        {
            var product = productRepository.GetProductByName(productName); 


            return View("GetAllProducts", product);
        }
        [HttpGet]
        public IActionResult GetProductSorting(string productName)
        {
            var product = productRepository.SortListing(productName); 


            return View("GetAllProducts", product);
        }

        [HttpGet]
        public IActionResult GetProductByid(int categoryId) 
        { 
            var product=productRepository.GetProductById(categoryId);
            return View("GetAllProducts",product);
        
        }
        public IActionResult DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
            return RedirectToAction("GetAllProducts");
        }
    }
}
