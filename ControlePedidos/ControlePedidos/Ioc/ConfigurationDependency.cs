using ControlePedidos.Data.Repositories;
using ControlePedidos.Interfaces.Repositories;
using ControlePedidos.Interfaces.Services;
using ControlePedidos.Services;

namespace ControlePedidos.Ioc
{
    public static class ConfigurationDependency
    {
        public static void InjectionDependency(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
