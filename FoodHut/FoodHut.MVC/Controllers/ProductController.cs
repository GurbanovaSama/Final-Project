using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodHut.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductsByCategory(int categoryId)
        {
            ICollection<GetProductDto> products = await _productService.GetProductsByCategoryIdAsync(categoryId);
            return PartialView("_ProductListPartial", products);
        }
    }
    
}
