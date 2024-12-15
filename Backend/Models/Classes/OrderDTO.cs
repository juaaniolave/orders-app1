namespace Backend.Models.Classes
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = "No Name";
        public string CustomerAddress { get; set; } = "No Address";
        public decimal TotalCost { get; set; } = 0;
        public string Status { get; set; } = "No Status";
    }

}