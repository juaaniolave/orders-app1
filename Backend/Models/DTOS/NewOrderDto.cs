namespace Backend.Models.DTOS
{
    public class NewOrderDto
    {
        public string OrderDate { get; set; }          // Fecha de la orden
        public int CustomerId { get; set; }           // ID del cliente
        public string Status { get; set; }            // Estado de la orden
        public int StatusId { get; set; }            // Estado de la orden
        public decimal TotalCost { get; set; }        // Costo total
        public string Comment { get; set; }           // Comentarios

        // Lista de productos con ID y cantidad
        public List<ProductDto> Products { get; set; }
    }



}