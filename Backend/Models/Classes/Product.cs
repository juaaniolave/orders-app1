namespace Backend.Models.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }

}