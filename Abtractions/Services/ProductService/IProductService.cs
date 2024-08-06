using AccountShop.Entities;
using System.Linq.Expressions;

namespace AccountShop.Abtractions.Services.ProductService
{
    public interface IProductService
    {
        public Task<Product> FindAsync(string ID);

        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>>? predicate);

        public Task Insert(Product entity);

        public Task Update(Product entity);

        public Task Delete(Product entity);
    }
}