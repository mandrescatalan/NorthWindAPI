using NorthWind.Sales.BusinessObjects.DTOs.CreateOrder;

namespace NorthWind.Sales.Presenters
{
    public class GetOrderByIdPresenter : IGetOrderByIdPresenter
    {
        public CreateOrderDTO OrderDTO { get; private set; }

        public ValueTask Handle(CreateOrderDTO order)
        {
            OrderDTO = order;
            return ValueTask.CompletedTask;
        }
    }
}
