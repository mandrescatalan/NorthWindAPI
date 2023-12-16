namespace NorthWind.Sales.BusinessObjects.Interfaces.Controllers
{
    public interface IGetOrderByIdController
    {
        ValueTask<CreateOrderDTO> GetOrderById(int orderId);
    }
}
