namespace Backend.Models.DTOS
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Cost { get; set; }

        public int Quantity { get; set; }
    }

}