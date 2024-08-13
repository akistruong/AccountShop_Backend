using System.Data;
using System.Linq.Expressions;

namespace AccountShop.Abtractions.Repositories
{
    /// <summary>
    /// Defines a generic repository interface for performing CRUD operations on entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the key used to identify the entity.</typeparam>
    public interface IGenericRepository<TEntity, TKey>
    {
        /// <summary>
        /// Begins a new database transaction asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains the database transaction.</returns>
        Task<IDbTransaction> BeginTransactionAsync();

        /// <summary>
        /// Finds an entity asynchronously by its unique identifier.
        /// </summary>
        /// <param name="ID">The unique identifier of the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity if found; otherwise, null.</returns>
        Task<TEntity> FindAsync(TKey ID);

        /// <summary>
        /// Finds all entities that match the specified predicate.
        /// </summary>
        /// <param name="expression">The predicate to filter the entities.</param>
        /// <returns>An IQueryable of entities that match the predicate.</returns>
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>>? expression);

        /// <summary>
        /// Inserts a new entity into the repository.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Saves all changes made in this context to the database asynchronously.
        /// </summary>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> SaveChangeAsync(CancellationToken token);
    }
}