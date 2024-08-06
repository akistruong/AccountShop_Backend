using AccountShop.Abtractions.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace AccountShop.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDbTransaction> BeginTransactionAsync()
        {
            IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
            return transaction.GetDbTransaction();
        }

        public async Task CommitAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>()
        {
            Type GenericRepositoryType = typeof(GenericRepository<,>).MakeGenericType(typeof(TEntity), typeof(TKey));
            object? Instance = Activator.CreateInstance(GenericRepositoryType, _dbContext);
            return (IGenericRepository<TEntity, TKey>)Instance!;
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}