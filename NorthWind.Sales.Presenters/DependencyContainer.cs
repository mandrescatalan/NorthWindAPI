namespace NorthWind.Sales.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(
            this IServiceCollection services)
        {
            services.AddScoped<CreateOrderPresenter>();
            services.AddScoped<GetOrderByIdPresenter>();

            services.AddScoped<ICreateOrderOutputPort>(
                provider => provider.GetService<CreateOrderPresenter>());

            services.AddScoped<ICreateOrderPresenter>(
                provider => provider.GetService<CreateOrderPresenter>());

            services.AddScoped<IGetOrderByIdOutputPort>(
                provider => provider.GetService<GetOrderByIdPresenter>());

            services.AddScoped<IGetOrderByIdPresenter>(
                provider => provider.GetService<GetOrderByIdPresenter>());

            return services;
        }
    }
}
