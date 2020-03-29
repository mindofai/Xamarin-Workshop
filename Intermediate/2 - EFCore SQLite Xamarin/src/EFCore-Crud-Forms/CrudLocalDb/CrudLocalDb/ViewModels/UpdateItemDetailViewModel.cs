using CrudLocalDb.Database;
using CrudLocalDb.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudLocalDb.ViewModels
{
    public class UpdateItemDetailViewModel : BaseItemViewModel
    {
        #region Fields

        private readonly Item _itemToUpdate;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the save command.
        /// </summary>
        public ICommand SaveCommand => new Command(async () => await SaveAsync());

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateItemDetailViewModel"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public UpdateItemDetailViewModel(Item item) : base(new ItemRepository())
        {
            _itemToUpdate = item;
            Name = item.Text;
            Description = item.Description;
            Title = "Update item";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Save the updates.
        /// </summary>
        public async Task SaveAsync()
        {
            _itemToUpdate.Text = Name;
            _itemToUpdate.Description = Description;

            await Repository.UpdateAsync(_itemToUpdate);
            await Repository.SaveAsync();

            await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PopAsync();
        }

        #endregion
    }
}