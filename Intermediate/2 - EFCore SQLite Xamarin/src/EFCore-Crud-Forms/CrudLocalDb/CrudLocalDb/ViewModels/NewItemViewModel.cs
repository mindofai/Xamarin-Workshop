using CrudLocalDb.Database;
using CrudLocalDb.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudLocalDb.ViewModels
{
    public class NewItemViewModel : BaseItemViewModel
    {
        #region Fields

        private string _tagText = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the tag text.
        /// </summary>
        public string TagText
        {
            get
            {
                return _tagText;
            }
            set
            {
                SetProperty(ref _tagText, value);
            }
        }

        /// <summary>
        /// Gets the save command.
        /// </summary>
        public ICommand SaveCommand => new Command(async () => await SaveAsync());

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="NewItemViewModel"/> class.
        /// </summary>
        public NewItemViewModel() : base(new ItemRepository())
        {
        }

        #region Methods

        /// <summary>
        /// Saves new item.
        /// </summary>
        public async Task SaveAsync()
        {
            var tags = TagText.Split(',');
            var itemToAdd = new Item()
            {
                Text = Name,
                Description = Description
            };

            foreach(var tag in tags)
            {
                itemToAdd.Tags.Add(new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = tag
                });
            }

            await Repository.CreateAsync(itemToAdd);
            await Repository.SaveAsync();
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        #endregion
    }
}