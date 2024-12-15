namespace Backend.Data.Queries
{
    public static class OrderQueries
    {
        public static string GetOrdersQuery => @"
            SELECT o.Id, 
                c.Name AS CustomerName, 
                c.Address AS CustomerAddress, 
                SUM(p.Cost) AS TotalCost, 
                s.Name AS Status
            FROM [Order] o
            LEFT JOIN [Customer] c ON o.CustomerId = c.Id
            LEFT JOIN [OrderProduct] op ON o.Id = op.OrderId
            LEFT JOIN [Product] p ON op.ProductId = p.Id
            LEFT JOIN [Status] s ON s.Id = o.StatusId
            GROUP BY o.Id, c.Name, c.Address, s.Name";
    }
}