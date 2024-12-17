using Microsoft.EntityFrameworkCore;
using Backend.Models.Classes;

namespace Backend.Data
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        // Entidades mapeadas a tablas
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; } // Tabla intermedia

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar las claves primarias
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Status>().HasKey(s => s.Id);
            modelBuilder.Entity<OrderProduct>().HasKey(op => op.Id);

            // Configuración de la relación Order -> Customer
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer) // Relación: Order tiene un Customer
                .WithMany(c => c.Orders) // Relación inversa: Customer tiene muchas Orders
                .HasForeignKey(o => o.CustomerId);

            // Configuración de la relación Order -> Status
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Status) // Relación: Order tiene un Status
                .WithMany() // Status no necesita una referencia inversa
                .HasForeignKey(o => o.StatusId);

            // Configuración de la tabla intermedia OrderProduct (Many-to-Many)

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProduct)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProduct)
                .HasForeignKey(op => op.ProductId);
        }
    }
}
