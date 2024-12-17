using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models.Classes
{
    [Table("Order")] // Aquí especificas el nombre exacto de la tabla en la base de datos
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public int StatusId { get; set; }
        public string Comment { get; set; }

        //Navigation properties
        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
    }

}