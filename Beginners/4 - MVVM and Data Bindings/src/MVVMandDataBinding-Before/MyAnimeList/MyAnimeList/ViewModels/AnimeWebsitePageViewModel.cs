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
    }
}
