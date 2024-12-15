using Backend.Models.Classes;

public interface IOrderRepository
{
    Task<List<OrderDTO>> GetOrdersAsync();
}