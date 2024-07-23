using AccountShop.Entities;

namespace AccountShop.Abtractions.Repositories
{
    public interface IProductRepository : IGenericRepository<Product, string>
    {
    }
}