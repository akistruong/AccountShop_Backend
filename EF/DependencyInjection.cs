using AccountShop.Abtractions.Repositories;
using AccountShop.EF.Options;
using AccountShop.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccountShop.EF
{
    public static class DependencyInjection
    {
        public static IServiceCollection PersistenceRegister(this IServiceCollection services, IConfiguration configuration)
        {
            DbOptions options = new DbOptions();
            configuration.GetSection(DbOptions.ConnectionStrings).Bind(options);
            services.AddDbContext<DatabaseContext>(option => option.UseMySQL(options.MySQL));
            services.RegisterRepository();
            return services;
        }

        public static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            return services;
        }
    }
}