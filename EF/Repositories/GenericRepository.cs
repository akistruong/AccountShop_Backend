using AccountShop.Abtractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AccountShop.EF.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DatabaseContext _context;
        private DbSet<TEntity>? _entities;

        public GenericRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<TEntity>();
                }

                return _entities;
            }
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>>? expression)
        {
            IQueryable<TEntity> query = Entities.AsQueryable();
            IQueryable<TEntity> result = expression is not null ? Entities.AsQueryable().Where(expression) : query;
            return result;
        }

        public async Task<TEntity> FindAsync(TKey ID)
        {
            return await Entities.FindAsync(ID);
        }

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }

        public async Task<int> SaveChangeAsync(CancellationToken token)
        {
            return await _context.SaveChangesAsync(token);
        }

        public void Update(TEntity entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
        }
    }
}