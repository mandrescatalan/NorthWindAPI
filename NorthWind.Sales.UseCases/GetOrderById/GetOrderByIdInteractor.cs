namespace NorthWind.Sales.UseCases.GetOrderById
{
    public class GetOrderByIdInteractor : IGetOrderByIdInputPort
    {
        readonly IGetOrderByIdOutputPort OutputPort;
        readonly INorthWindSalesQueriesRepository Repository;

        public GetOrderByIdInteractor(IGetOrderByIdOutputPort outputPort, INorthWindSalesQueriesRepository repository)
        {
            OutputPort = outputPort;
            Repository = repository;
        }

        public async ValueTask Handle(int orderId)
        {
            var order = await Repository.GetOrderId(orderId);

            var orderDto = new CreateOrderDTO();

            if (order != null)
            {
                orderDto = new CreateOrderDTO()
                {
                    CustomerId = order.CustomerId,
                    ShipAddress = order.ShipAddress,
                    ShipCity = order.ShipCity,
                    ShipCountry = order.ShipCountry,
                    ShipPostalCode = order.ShipPostalCode
                };
            }

            await OutputPort.Handle(orderDto);
        }
    }
}
