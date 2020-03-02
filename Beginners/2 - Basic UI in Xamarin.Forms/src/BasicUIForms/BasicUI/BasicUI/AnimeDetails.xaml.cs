using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasicUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimeDetails : ContentPage
    {
        public AnimeDetails(Anime anime)
        {
            InitializeComponent();
            AnimeName.Text = anime.Name;
            AnimeDescription.Text = anime.Description;
            AnimeImage.Source = anime.ImageUrl;
        }
    }
}