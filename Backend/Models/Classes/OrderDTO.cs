namespace Backend.Models.Classes
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }
    }
}