using CrudLocalDb.Database;
using CrudLocalDb.Models;
using CrudLocalDb.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudLocalDb.ViewModels
{
    public class ItemsViewModel : BaseItemViewModel
    {
        private ObservableCollection<Item> _items = new ObservableCollection<Item>();

        #region Properties

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public ObservableCollection<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                SetProperty(ref _items, value);
            }
        }

        /// <summary>
        /// Gets or sets the load items command.
        /// </summary>
        public Command LoadItemsCommand { get; set; }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        public ICommand UpdateCommand => new Command(async (data) => await NavigateToUpdatePage(data as Item));

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        public ICommand DeleteCommand => new Command(async (data) => await DeleteAsync(data as Item));

        /// <summary>
        /// Gets the add item command.
        /// </summary>
        public ICommand AddItemCommand => new Command(async () => await NavigateToAddPageAsync());

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsViewModel"/> class.
        /// </summary>
        public ItemsViewModel() : base(new ItemRepository())
        {
            Title = "Browse";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        #endregion

        #region Methods

        /// <summary>
        /// Goes to add page.
        /// </summary>
        public async Task NavigateToAddPageAsync()
        {
            await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        /// <summary>
        /// Goes to update page.
        /// </summary>
        /// <param name="item">The item.</param>
        public async Task NavigateToUpdatePage(Item item)
        {
            await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync(new UpdateItemDetailPage(new UpdateItemDetailViewModel(item)));
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="item">The item.</param>
        public async Task DeleteAsync(Item item)
        {
            IsBusy = true;
            await Repository.DeleteAsync(item);
            await Repository.SaveAsync();
            IsBusy = false;
            await ExecuteLoadItemsCommand();
        }

        /// <summary>
        /// Executes the load items command.
        /// </summary>
        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items = new ObservableCollection<Item>();
                var items = await Repository.GetAllAsync();

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}