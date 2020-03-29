using System;

namespace CrudLocalDb.Database
{
    public interface IEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        Guid Id { get; set; }

        #endregion
    }
}