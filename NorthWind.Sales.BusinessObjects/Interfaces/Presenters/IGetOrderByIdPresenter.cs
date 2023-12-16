namespace NorthWind.Sales.BusinessObjects.Interfaces.Presenters
{
    public interface IGetOrderByIdPresenter : IGetOrderByIdOutputPort
    {
        CreateOrderDTO OrderDTO { get; }
    }
}
