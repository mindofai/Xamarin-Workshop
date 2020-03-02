using MyAnimeList.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAnimeList.ViewModels
{
    public class AnimeWebsitePageViewModel : ViewModelBase
    {
        public AnimeWebsitePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private AnimeDetailsModel _selectedAnime;
        public AnimeDetailsModel SelectedAnime
        {
            get => _selectedAnime;
            set => SetProperty(ref _selectedAnime, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            SelectedAnime = parameters.GetValue<AnimeDetailsModel>("SelectedAnime");
        }
    }
}
