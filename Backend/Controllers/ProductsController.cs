using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models.Classes;

namespace OrdersApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly OrdersDbContext _context;

        public ProductsController(OrdersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            // Obtiene todos los productos directamente desde la tabla Products
            var products = await _context.Product.ToListAsync();

            return Ok(products);
        }
    }
}
