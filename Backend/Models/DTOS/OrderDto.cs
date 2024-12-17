namespace Backend.Models.DTOS
{
    public class OrderDto
    {
        public int Id { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerAddress { get; set; }
        public decimal TotalCost { get; set; }
        public required string Status { get; set; }
    }

}