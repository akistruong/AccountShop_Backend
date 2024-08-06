using AccountShop.Abtractions.Repositories;
using AccountShop.Abtractions.Services.ProductService;
using AccountShop.Entities;
using System.Linq.Expressions;

namespace AccountShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository ProductRepository;
        private readonly IUnitOfWork UnitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            ProductRepository = productRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task Delete(Product entity)
        {
            UnitOfWork.Repository<Product, string>().Delete(entity);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task Insert(Product entity)
        {
            UnitOfWork.Repository<Product, string>().Insert(entity);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task Update(Product entity)
        {
            UnitOfWork.Repository<Product, string>().Update(entity);
            await UnitOfWork.SaveChangeAsync();
        }

        Task<Product> IProductService.FindAsync(string ID)
        {
            return ProductRepository.FindAsync(ID);
        }

        IEnumerable<Product> IProductService.GetAll(Expression<Func<Product, bool>>? predicate)
        {
            return ProductRepository.FindAll(null);
        }
    }
}