using CrudLocalDb.Database;
using CrudLocalDb.Models;
using System.Collections.Generic;

namespace CrudLocalDb.ViewModels
{
    public class ItemDetailViewModel : BaseItemViewModel
    {
        #region Properties

        public IEnumerable<Tag> Tags{ get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDetailViewModel"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public ItemDetailViewModel(Item item) : base(new ItemRepository())
        {
            Name = item.Text;
            Description = item.Description;
            Title = "Details";
            Tags = item.Tags;
        }

        #endregion
    }
}