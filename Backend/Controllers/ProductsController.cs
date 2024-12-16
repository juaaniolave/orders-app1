using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models.Classes;
using Backend.Data.Queries;

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
            var products = await _context.Database
                .SqlQueryRaw<Product>(OrderQueries.GetProductsQuery)
                .ToListAsync();
            return Ok(products);
        }
    }
}
