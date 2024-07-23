using System.Data;

namespace AccountShop.Abtractions.Repositories
{
    /// <summary>
    /// Represents a unit of work that encapsulates a set of database operations.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all changes made in the context to the database asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        Task SaveChangeAsync();

        /// <summary>
        /// Begins a new database transaction asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains the database transaction.</returns>
        Task<IDbTransaction> BeginTransactionAsync();

        /// <summary>
        /// Gets the generic repository for the specified entity type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TKey">The type of the primary key of the entity.</typeparam>
        /// <returns>The repository for the specified entity type.</returns>
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>();

        /// <summary>
        /// Commits the current transaction asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CommitAsync();
    }
}