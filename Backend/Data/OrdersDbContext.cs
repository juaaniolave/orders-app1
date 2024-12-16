namespace Backend.Data
{
    using Microsoft.EntityFrameworkCore;
    using Backend.Models.Classes;
    using System.Net.Http.Headers;

    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<OrderDTO> Order { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}
