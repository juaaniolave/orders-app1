using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models.DTOS;

namespace OrdersApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly OrdersDbContext _context;

        public CustomersController(OrdersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            // Utilizando Entity Framework para obtener los datos de la tabla Customers
            var customers = await _context.Customer
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address
                    // Address = c.Address
                })
                .ToListAsync();

            return Ok(customers);
        }
    }
}
