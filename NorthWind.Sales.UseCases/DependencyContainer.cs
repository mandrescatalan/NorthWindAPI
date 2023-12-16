
using NorthWind.Sales.UseCases.GetOrderById;

namespace NorthWind.Sales.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
            services.AddScoped<IGetOrderByIdInputPort, GetOrderByIdInteractor>();
            return services;
        }
    }
}
