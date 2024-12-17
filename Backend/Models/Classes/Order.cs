namespace Backend.Models.Classes
{
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
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }

}