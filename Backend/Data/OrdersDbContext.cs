namespace Backend.Data
{
    using Microsoft.EntityFrameworkCore;
    using Backend.Models.Classes;

    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<OrderDTO> Order { get; set; }
    }
}
