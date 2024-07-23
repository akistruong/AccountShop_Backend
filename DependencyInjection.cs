using AccountShop.Abtractions.Services.ProductService;
using AccountShop.Services;
using System.Reflection;

namespace AccountShop
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}