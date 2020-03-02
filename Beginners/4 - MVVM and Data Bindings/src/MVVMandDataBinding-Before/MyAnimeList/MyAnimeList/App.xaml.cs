using Prism;
using Prism.Ioc;
using MyAnimeList.ViewModels;
using MyAnimeList.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyAnimeList
{
    public partial class App
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/SearchAnimePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SearchAnimePage, SearchAnimePageViewModel>();
            containerRegistry.RegisterForNavigation<AnimeDetailsPage, AnimeDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<AnimeWebsitePage, AnimeWebsitePageViewModel>();
        }
    }
}
