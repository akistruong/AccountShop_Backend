using AccountShop.Abtractions.Repositories;
using AccountShop.Entities;

namespace AccountShop.EF.Repositories
{
    public class ProductRepository : GenericRepository<Product, string>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }
    }
}