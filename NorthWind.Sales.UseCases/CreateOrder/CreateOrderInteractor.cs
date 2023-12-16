
namespace NorthWind.Sales.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly ICreateOrderOutputPort OutputPort;
        readonly INorthWindSalesCommandsRepository Repository;

        public CreateOrderInteractor(ICreateOrderOutputPort outputPort, INorthWindSalesCommandsRepository repository)
        {
            OutputPort = outputPort;
            Repository = repository;
        }

        public async ValueTask Handle(CreateOrderDTO orderDto)
        {
            //posible uso del automaper - pero es mejor evitar el uso de 3
            OrderAggregate Order = new OrderAggregate
            {
                CustomerId = orderDto.CustomerId,
                ShipAddress = orderDto.ShipAddress,
                ShipCity = orderDto.ShipCity,
                ShipCountry = orderDto.ShipCountry,
                ShipPostalCode = orderDto.ShipPostalCode
            };

            foreach (var Item in orderDto.OrderDetails)
            {
                Order.AddDetail(Item.ProductId, Item.UnitPrice, Item.Quantity);
            }

            await Repository.CreateOrder(Order);
            await Repository.SaveChanges();
            await OutputPort.Handle(Order.Id);

        }
    }
}
