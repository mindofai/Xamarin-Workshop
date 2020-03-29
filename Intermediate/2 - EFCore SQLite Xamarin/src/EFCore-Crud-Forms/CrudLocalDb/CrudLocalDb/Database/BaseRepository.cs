using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudLocalDb.Database
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        #region Properties

        protected AppDbContext DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        public BaseRepository()
        {
            DbContext = new AppDbContext();
            DbSet = DbContext.Set<TEntity>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the enttiy.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async Task CreateAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public Task UpdateAsync(TEntity entity)
        {
            DbContext.Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(DbSet.AsNoTracking() as IEnumerable<TEntity>);
        }

        /// <summary>
        /// Gets the entity by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<TEntity> GetByIdAsync(Guid id)
        {
            return Task.FromResult(DbSet.FirstOrDefault(e => e.Id == id));
        }

        /// <summary>
        /// Saves the entity.
        /// </summary>
        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        #endregion
    }
}