using CrudLocalDb.Database;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrudLocalDb.ViewModels
{
    public abstract class BaseItemViewModel : BaseViewModel
    {
        #region Fields

        private string _name;
        private string _description;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the repository.
        /// </summary>
        public IItemRepository Repository { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                SetProperty(ref _description, value);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseItemViewModel"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected BaseItemViewModel(IItemRepository repository)
        {
            Repository = repository;
        }

        public void PerformDbOperations()
        {
            using (var context = new AppDbContext())
            {
                // Get all items
                var items = context.Items;
                foreach(var item in items)
                {
                    Console.WriteLine($"Description: {item.Text}");
                }

                var firstItem = items.FirstOrDefault();
                var lastItem = items.LastOrDefault();

                // Update the first item
                firstItem.Text = "New text";
                firstItem.Description = "New description";

                // Delete the last item
                context.Items.Remove(lastItem);

                // You can perform LINQ operations.
                var filteredItems = items.Where(item => item.Id.ToString() == "123");
            }
        }

        #endregion
    }
}