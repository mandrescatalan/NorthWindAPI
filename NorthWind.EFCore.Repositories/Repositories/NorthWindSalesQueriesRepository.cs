namespace NorthWind.EFCore.Repositories.Repositories
{
    public class NorthWindSalesQueriesRepository : INorthWindSalesQueriesRepository
    {
        readonly NorthWindSalesContext Context;
        public NorthWindSalesQueriesRepository(NorthWindSalesContext context) =>
            Context = context;

        public async ValueTask<List<Order>> GetOrders()
        {
            return await Context.Orders.ToListAsync();
        }

        public async ValueTask<Order> GetOrderId(int orderId)
        {
            return await Context.Orders.FindAsync(orderId);
        }
    }
}
