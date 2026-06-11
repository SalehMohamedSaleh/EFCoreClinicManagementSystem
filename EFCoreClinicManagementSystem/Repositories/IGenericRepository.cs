using System.Linq.Expressions;

namespace EFCoreClinicManagementSystem.Repositories
{
    /// <summary>
    /// Generic repository interface defining common CRUD operations for all entities
    /// </summary>
    /// <typeparam name="TEntity">The entity type</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all entities from the database
        /// </summary>
        /// <returns>IQueryable of entities</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Get an entity by its ID
        /// </summary>
        /// <param name="id">The entity ID</param>
        /// <returns>The entity or null if not found</returns>
        Task<TEntity?> GetByIdAsync(int id);

        /// <summary>
        /// Get entities based on a predicate
        /// </summary>
        /// <param name="predicate">The filter predicate</param>
        /// <returns>IQueryable of filtered entities</returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Add a new entity to the database
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns>The added entity</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Add multiple entities to the database
        /// </summary>
        /// <param name="entities">The entities to add</param>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update an existing entity
        /// </summary>
        /// <param name="entity">The entity to update</param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Delete an entity by its ID
        /// </summary>
        /// <param name="id">The entity ID</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Delete multiple entities
        /// </summary>
        /// <param name="entities">The entities to delete</param>
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Check if any entity exists matching the predicate
        /// </summary>
        /// <param name="predicate">The filter predicate</param>
        /// <returns>True if any entity exists, otherwise false</returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get the count of entities matching the predicate
        /// </summary>
        /// <param name="predicate">The filter predicate (optional)</param>
        /// <returns>Count of entities</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
    }
}
