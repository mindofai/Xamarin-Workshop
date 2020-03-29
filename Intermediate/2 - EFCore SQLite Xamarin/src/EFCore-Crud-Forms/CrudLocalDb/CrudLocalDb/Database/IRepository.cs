using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudLocalDb.Database
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Creates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task CreateAsync(TEntity entity);

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Gets the entity by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets all the entities.
        /// </summary>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Saves the entity.
        /// </summary>
        Task SaveAsync();
    }
}