using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models.Classes
{
    [Table("Customer")] // Aquí especificas el nombre exacto de la tabla en la base de datos

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}