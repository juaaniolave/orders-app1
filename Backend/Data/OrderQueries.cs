namespace Backend.Data.Queries
{
    public static class OrderQueries
    {
        public static string GetOrdersQuery => @"
SELECT 
    o.Id, 
    ISNULL(c.Name, 'No Name') AS CustomerName, 
    ISNULL(c.Address, 'No Address') AS CustomerAddress,
    ISNULL(SUM(p.Cost), 0) AS TotalCost,
    ISNULL(s.Name, 'No Status') AS Status
FROM [Order] o
LEFT JOIN Customer c ON o.CustomerId = c.Id
LEFT JOIN OrderProduct op ON o.Id = op.OrderId
LEFT JOIN Product p ON op.ProductId = p.Id
LEFT JOIN Status s ON s.Id = o.StatusId
GROUP BY o.Id, c.Name, c.Address, s.Name";
    }
}