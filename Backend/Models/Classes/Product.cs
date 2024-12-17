using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models.Classes
{
    [Table("Product")] // Aquí especificas el nombre exacto de la tabla en la base de datos
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
    }

}