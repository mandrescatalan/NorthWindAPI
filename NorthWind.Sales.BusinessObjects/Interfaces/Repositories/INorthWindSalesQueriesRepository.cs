namespace NorthWind.Sales.BusinessObjects.Interfaces.Repositories
{
    public interface INorthWindSalesQueriesRepository
    {
        ValueTask<Order> GetOrderId(int orderId);

        ValueTask<List<Order>> GetOrders();
    }
}
