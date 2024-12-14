using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;

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
            var orders = await _context.Order
                .FromSqlRaw(@"
                    SELECT o.Id, 
                        c.Name AS CustomerName, 
                        c.Address AS CustomerAddress, 
                        SUM(p.Cost) AS TotalCost, 
                        s.Name AS Status
                    FROM [Order] o
                    left JOIN [Customer] c ON o.CustomerId = c.Id
                    left JOIN [OrderProduct] op ON o.Id = op.OrderId
                    left JOIN [Product] p ON op.ProductId = p.Id
                    left JOIN [Status] s ON s.Id = o.StatusId
                    GROUP BY o.Id, c.Name, c.Address, s.Name")
                .ToListAsync();
            foreach (var order in orders)
            {
                Console.WriteLine($"Id: {order.Id}, CustomerName: {order.CustomerName}, " +
                      $"CustomerAddress: {order.CustomerAddress}, TotalCost: {order.TotalCost}, Status: {order.Status}");
            }

            return Ok(orders);
        }
    }
}
