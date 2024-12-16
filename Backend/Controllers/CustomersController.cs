using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models.Classes;
using Backend.Data.Queries;

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
            var Customers = await _context.Database
                .SqlQueryRaw<Customer>(OrderQueries.GetCustomersQuery)
                .ToListAsync();
            return Ok(Customers);
        }
    }
}
