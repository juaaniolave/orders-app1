namespace Backend.Models.DTOS
{
    public class OrderProductDto
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}