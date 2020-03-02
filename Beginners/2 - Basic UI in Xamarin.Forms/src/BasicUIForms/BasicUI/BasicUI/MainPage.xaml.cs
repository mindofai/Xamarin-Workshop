using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BasicUI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public IList<Anime> AnimeList { get; private set; }
        MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel();

            AnimeList = new List<Anime>();
            AnimeList.Add(new Anime
            {
                Name = "Hunter X Hunter",
                Description = "Hunter X Hunter is a Japanese manga series written and illustrated by Yoshihiro Togashi. It has been serialized in Weekly Shōnen Jump magazine since March 16, 1998.",
                ImageUrl = "hunterx.jpg"
            });

            AnimeList.Add(new Anime
            {
                Name = "Naruto",
                Description = "Naruto is a Japanese manga series written and illustrated by Masashi Kishimoto. It tells the story of Naruto Uzumaki, a young ninja who seeks to gain recognition from his peers and also dreams of becoming the Hokage, the leader of his village. ",
                ImageUrl = "naruto.jpg"
            });

            AnimeList.Add(new Anime
            {
                Name = "One Piece",
                Description = "One Piece is a Japanese anime television series adapted from the manga of the same name by Eiichiro Oda. The story follows the adventures of Monkey D. Luffy, a boy whose body gained the properties of rubber after unintentionally eating a Devil Fruit.",
                ImageUrl = "onepiece.jpg"
            });

            AnimeList.Add(new Anime
            {
                Name = "One Punch",
                Description = "One Punch is a Japanese superhero webcomic created by the artist One in early 2009. It has a manga adaptation illustrated by Yusuke Murata, as well as an anime adaptation. Following its publication, the webcomic quickly went viral, surpassing 7.9 million hits in June 2012.",
                ImageUrl = "onepunch.jpg"
            });
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Anime;
            if (item == null)
                return;

            await Navigation.PushModalAsync(new AnimeDetails( item));

            // Manually deselect item.
            animeListView.SelectedItem = null;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            animeListView.ItemsSource = AnimeList;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(AnimeList.Count > 0)
            {
                var result =  AnimeList.Where(r => r.Name.ToLower().Contains(txtAnime.Text.ToLower())).ToList();
                animeListView.ItemsSource = null;
                animeListView.ItemsSource = result;
            }
        }
    }
}
