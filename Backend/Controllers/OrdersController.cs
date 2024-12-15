using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models.Classes;
using Backend.Data.Queries;

namespace OrdersApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersDbContext _context;

        public OrdersController(OrdersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _context.Database
                .SqlQueryRaw<OrderDTO>(OrderQueries.GetOrdersQuery)
                .ToListAsync();
            return Ok(orders);
        }
    }
}
