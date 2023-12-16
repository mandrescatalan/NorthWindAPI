namespace NorthWind.Sales.BusinessObjects.Interfaces.Ports
{
    public interface IGetOrderByIdInputPort
    {
        ValueTask Handle(int orderId);
    }
}
