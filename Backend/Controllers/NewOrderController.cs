using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models.Classes;
using Microsoft.EntityFrameworkCore;
using Backend.Models.DTOS;

namespace OrdersApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewOrderController : ControllerBase
    {
        private readonly OrdersDbContext _context;

        public NewOrderController(OrdersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            try
            {
                // Obtiene todos los estados desde la base de datos usando EF
                var status = await _context.Status.ToListAsync();

                if (status == null || status.Count == 0)
                    return NotFound("No statuses found.");

                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/neworder
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] NewOrderDto newOrderDto)
        {
            if (newOrderDto == null)
                return BadRequest("Order data is null.");

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Crear una nueva instancia de Order
                var order = new Order
                {
                    CustomerId = newOrderDto.CustomerId,
                    StatusId = newOrderDto.StatusId,
                    OrderDate = DateTime.Parse(newOrderDto.OrderDate),
                    Comment = newOrderDto.Comment
                };

                // Agregar la orden a la base de datos
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                // Insertar productos relacionados en OrderProducts
                foreach (var productDto in newOrderDto.Product)
                {
                    var orderProduct = new OrderProduct
                    {
                        OrderId = order.Id,
                        ProductId = productDto.Id,
                        Quantity = productDto.Quantity
                    };

                    _context.OrderProduct.Add(orderProduct);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { message = "Order created successfully", orderId = order.Id });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while creating the order.");
            }
        }
    }
}
