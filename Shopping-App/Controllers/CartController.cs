using Microsoft.AspNetCore.Mvc;
using Shopping_App.Models;
using Shopping_App.Service;

namespace Shopping_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "T-Shirt", Description = "Black Bella Canvas", Price = 19.00M, ImageUrl = "https://example.com/tshirt.png" },
            new Product { Id = 2, Name = "Blue Drill Jeans", Description = "100% cotton drill - 5 pockets", Price = 118.00M, ImageUrl = "https://example.com/jeans.png" },
            new Product { Id = 3, Name = "Leather Arm Band", Description = "Genuine Leather", Price = 23.00M, ImageUrl = "https://example.com/armband.png" }
        };

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public ActionResult<Cart> GetCart()
        {
            return Ok(_cartService.GetCart());
        }

        [HttpPost("add/{id}")]
        public IActionResult AddProductToCart(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _cartService.AddProduct(product);
            return Ok(_cartService.GetCart());
        }

        [HttpDelete("remove/{id}")]
        public IActionResult RemoveProductFromCart(int id)
        {
            _cartService.RemoveProduct(id);
            return Ok(_cartService.GetCart());
        }

        [HttpPost("clear")]
        public IActionResult ClearCart()
        {
            _cartService.ClearCart();
            return Ok(_cartService.GetCart());
        }
    }
}
