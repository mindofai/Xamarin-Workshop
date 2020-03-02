using MyAnimeList.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyAnimeList.ViewModels
{
    public class SearchAnimePageViewModel : ViewModelBase
    {

        #region Fields

        private List<AnimeDetailsModel> _animeDetails;
        private string _searchKeyword;
        private bool _isRefreshing;
        static readonly HttpClient httpClient = new HttpClient();

        #endregion

        #region Properties

        protected IPageDialogService DialogService { get; private set; }

        public string SearchKeyword
        {
            get => _searchKeyword;
            set
            {
                SetProperty(ref _searchKeyword, value);
            }
        }

        public bool IsRefreshing 
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public List<AnimeDetailsModel> AnimeDetails
        {
            get => _animeDetails;
            set => SetProperty(ref _animeDetails, value);
        }

        public DelegateCommand<AnimeDetailsModel> ItemTappedCommand { get; private set; }

        public DelegateCommand SearchCommand { get; private set; }

        public DelegateCommand RefreshCommand { get; private set; }

        #endregion

        #region Constructor

        public SearchAnimePageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {

            DialogService = dialogService;

            ItemTappedCommand = new DelegateCommand<AnimeDetailsModel>(async (item) => await ExecuteItemTappedCommand(item));

            SearchCommand = new DelegateCommand(async() => await ExecuteSearchCommand());

            RefreshCommand = new DelegateCommand(async () => await ExecuteRefreshCommand());

        }

        #endregion

        #region Methods

        private async Task PerformSearch()
        {

            var networkAccess = Connectivity.NetworkAccess;

            if (networkAccess == NetworkAccess.Internet)
            {

                var url = $"{Constants.BaseAddress}{SearchKeyword}{Constants.Limit}{5}";
                
                HttpResponseMessage httpResponse = await httpClient.GetAsync(url);
                string httpResult = httpResponse.Content.ReadAsStringAsync().Result;
                var httpData = JsonConvert.DeserializeObject<AnimeListModel>(httpResult);

                AnimeDetails = httpData.Animes;

            }

            else 
            {
                await DialogService.DisplayAlertAsync("Network error", "Please check your internet connection and try again.", "OK");
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        #endregion


        #region Commands

        private async Task ExecuteItemTappedCommand(AnimeDetailsModel item)
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("SelectedAnime", item);

            await NavigationService.NavigateAsync("AnimeDetailsPage", navParameters);
        }


        private async Task ExecuteRefreshCommand() 
        {
            if (!string.IsNullOrWhiteSpace(SearchKeyword))
            {
                await PerformSearch();
            }

            IsRefreshing = false;
        }

        private async Task ExecuteSearchCommand() 
        {
            if (!string.IsNullOrWhiteSpace(SearchKeyword) && !IsRefreshing)
            {
                IsRefreshing = true;
                await PerformSearch();
                IsRefreshing = false;
            }
        }

        #endregion

        
    }
}
