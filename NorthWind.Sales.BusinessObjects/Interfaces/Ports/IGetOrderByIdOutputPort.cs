namespace NorthWind.Sales.BusinessObjects.Interfaces.Ports
{
    public interface IGetOrderByIdOutputPort
    {
        ValueTask Handle(CreateOrderDTO order);
    }
}
