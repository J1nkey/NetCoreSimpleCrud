using Microsoft.AspNetCore.Mvc;
using SimpleEcommerceApp.Models;
using SimpleEcommerceApp.Models.Products;
using SimpleEcommerceApp.Services.Products;

namespace SimpleEcommerceApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(string productName = "", int pageIndex = 1, int pageSize = 10)
        {
            var products = await _productRepository.GetProductsPaging(productName, pageIndex, pageSize);
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddProductRequestDto request)
        {
            _productRepository.CreateProduct(request);
            return View();
        }
    }
}
