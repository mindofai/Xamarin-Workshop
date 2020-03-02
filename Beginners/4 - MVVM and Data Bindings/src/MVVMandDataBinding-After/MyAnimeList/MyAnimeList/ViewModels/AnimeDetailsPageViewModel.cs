using MyAnimeList.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAnimeList.ViewModels
{
    public class AnimeDetailsPageViewModel : ViewModelBase
    {
        public AnimeDetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            VisitSiteCommand = new DelegateCommand(async () => await ExecuteVisitSiteCommand());
        }

        
        private AnimeDetailsModel _selectedAnime;
        public AnimeDetailsModel SelectedAnime
        {
            get => _selectedAnime;
            set => SetProperty(ref _selectedAnime, value);
        }

        public DelegateCommand VisitSiteCommand { get; private set; }

        private async Task ExecuteVisitSiteCommand()
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("SelectedAnime", SelectedAnime);

            await NavigationService.NavigateAsync("AnimeWebsitePage", navParameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if(SelectedAnime == null)
            {
                SelectedAnime = parameters.GetValue<AnimeDetailsModel>("SelectedAnime");
            }
        }
    }
}
