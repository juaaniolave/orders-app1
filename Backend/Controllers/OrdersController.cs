using Microsoft.AspNetCore.Mvc;
using Backend.Data;
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
            try
            {
                // Obtener las órdenes desde la base de datos usando EF
                var orders = await OrderQueries.GetOrdersAsync(_context);

                if (orders == null || orders.Count == 0)
                {
                    return NotFound("No orders found.");
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
