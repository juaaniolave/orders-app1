using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models.Classes
{
    [Table("OrderProduct")] // Aquí especificas el nombre exacto de la tabla en la base de datos
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } // Relación con Order
        public int ProductId { get; set; }
        public Product Product { get; set; } // Relación con Product
        public int Quantity { get; set; }
    }
}