using Backend.Models.Classes;
using Microsoft.EntityFrameworkCore;
using Backend.Models.DTOS;

namespace Backend.Data.Queries
{
    public static class OrderQueries
    {
        // Obtener lista de órdenes con datos relacionados (Customer, Products, Status)
        public static async Task<List<OrderDto>> GetOrdersAsync(OrdersDbContext context)
        {
            return await context.Orders
                .Include(o => o.Customer)         // Relación con Customer
                .Include(o => o.Status)           // Relación con Status
                .Include(o => o.OrderProduct)    // Relación con OrderProducts
                    .ThenInclude(op => op.Product) // Relación con Product dentro de OrderProducts
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    CustomerName = o.Customer != null ? o.Customer.Name : "No Name",
                    CustomerAddress = o.Customer != null ? o.Customer.Address : "No Address",
                    Status = o.Status != null ? o.Status.Name : "No Status",
                    TotalCost = o.OrderProduct.Sum(op => op.Product.Cost * op.Quantity)
                })
                .ToListAsync();
        }

        // Obtener lista de productos
        public static async Task<List<ProductDto>> GetProductsAsync(OrdersDbContext context)
        {
            return await context.Product
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Cost = p.Cost
                })
                .ToListAsync();
        }

        // Obtener lista de clientes
        public static async Task<List<CustomerDto>> GetCustomersAsync(OrdersDbContext context)
        {
            return await context.Customer
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address
                })
                .ToListAsync();
        }

        // Obtener lista de estados
        public static async Task<List<StatusDto>> GetStatusesAsync(OrdersDbContext context)
        {
            return await context.Status
                .Select(s => new StatusDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
        }

        // Insertar una nueva orden
        public static async Task<int> InsertOrderAsync(OrdersDbContext context, NewOrderDto newOrderDto)
        {
            // Crear la nueva orden
            var order = new Order
            {
                CustomerId = newOrderDto.CustomerId,
                StatusId = newOrderDto.StatusId,
                OrderDate = DateTime.Parse(newOrderDto.OrderDate),
                Comment = newOrderDto.Comment
            };

            // Agregar la orden al contexto
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            // Insertar productos relacionados con la orden
            var orderProduct = newOrderDto.Product.Select(product => new OrderProduct
            {
                OrderId = order.Id,
                ProductId = product.Id,
                Quantity = product.Quantity
            }).ToList();

            context.OrderProduct.AddRange(orderProduct);
            await context.SaveChangesAsync();

            return order.Id; // Retorna el ID de la orden creada
        }
    }
}
