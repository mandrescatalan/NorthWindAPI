namespace NorthWind.Sales.Controllers
{
    public class GetOrderByIdController : IGetOrderByIdController
    {
        readonly IGetOrderByIdInputPort InputPort;
        readonly IGetOrderByIdPresenter Presenter;

        public GetOrderByIdController(IGetOrderByIdInputPort inputPort,
            IGetOrderByIdPresenter presenter) =>
            (InputPort, Presenter) = (inputPort, presenter);

        public async ValueTask<CreateOrderDTO> GetOrderById(int orderId)
        {
            await InputPort.Handle(orderId);
            return Presenter.OrderDTO;
        }
    }
}
