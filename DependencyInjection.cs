using System.Reflection;

namespace AccountShop
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); });
            return services;
        }
    }
}