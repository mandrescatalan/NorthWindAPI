

namespace NorthWind.Sales.WebApi
{
    public static class Endpoints
    {
        public static WebApplication UseNorthWindSalesEndpoints(
            this WebApplication app)
        {
            app.MapPost("/create",
                async (CreateOrderDTO order,
                ICreateOrderController controller) =>
                Results.Ok(await controller.CreateOrder(order)));

            app.MapGet("/getById/{orderId}",
                async (int orderId,
                IGetOrderByIdController controller) =>
                Results.Ok(await controller.GetOrderById(orderId)));

            return app;
        }
    }
}
