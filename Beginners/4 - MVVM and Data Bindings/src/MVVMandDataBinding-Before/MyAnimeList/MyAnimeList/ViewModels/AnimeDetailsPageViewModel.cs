using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAnimeList.ViewModels
{
    public class AnimeDetailsPageViewModel : ViewModelBase
    {
        public AnimeDetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
