

namespace NorthWind.Sales.BusinessObjects.Aggregates
{
    public class OrderAggregate : Order

    {   //Proteger valueObject

        //Trabajar de manera interna
        //Variable para almacenar una o mas ordenDetail - campo de solo lectura
        readonly List<OrderDetail> OrderDetailsField = new();

        //Para trabajar de manera externa
        //para que puedan asceder desde el exterior al detalle de la orden
        //(Exponer una collecion de solo lectura)
        public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;

        // Agregar el detalle de la orden.
        // Si ya se agregó un ID de producto previamente, sumar la cantidad.
        public void AddDetail(OrderDetail orderDetail)
        {
            var ExistingOrderDetail =
                OrderDetailsField.FirstOrDefault(
                     o => o.ProductId == orderDetail.ProductId);

            if (ExistingOrderDetail != default)
            {
                OrderDetailsField.Add(
                    //Regresa una nueva orden en base a ExistingOrderDetail pero con la cantidad distinta
                    ExistingOrderDetail with
                    {
                        Quantity = (short)
                        (ExistingOrderDetail.Quantity +
                        orderDetail.Quantity)
                    });

                OrderDetailsField.Remove(ExistingOrderDetail);
            }
            else
            {
                OrderDetailsField.Add(orderDetail);
            }
        }

        public void AddDetail(int productId, decimal unitPrice, short quantity) =>
            AddDetail(new OrderDetail(productId, unitPrice, quantity));
    }

}
