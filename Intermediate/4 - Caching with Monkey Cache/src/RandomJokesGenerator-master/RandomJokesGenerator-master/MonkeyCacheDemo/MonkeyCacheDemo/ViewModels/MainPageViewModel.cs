using MonkeyCacheDemo.Models;
using MonkeyCacheDemo.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MonkeyCacheDemo.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, IDisposable
    {

        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;
        private readonly JokesDataService _jokesDataService;
        private List<Jokes> _jokes;
        private bool _isRefreshing;
        private bool _isConnected;

        #endregion

        #region Properties

        public bool IsConnected 
        {
            get => _isConnected;
            set 
            {
                _isConnected = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public List<Jokes> Jokes
        {
            get => _jokes;
            set
            {
                _jokes = value;
                OnPropertyChanged(nameof(Jokes));
            }
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand { get; set; }

        #endregion

        #region Constructor

        public MainPageViewModel()
        {

            _jokesDataService = new JokesDataService();

            RefreshCommand = new Command(async () => await PerformSearch());

            IsConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            
            GetData();
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsConnected = e.NetworkAccess != NetworkAccess.Internet;
        }

        #endregion

        #region Methods

        private async void GetData()
        {
            if (!IsRefreshing)
            {
                IsRefreshing = true;
                await GetRandomJokesAsync();
                IsRefreshing = false;
            }
        }

        private async Task PerformSearch()
        {
            await GetRandomJokesAsync();
            IsRefreshing = false;
        }

        private async Task GetRandomJokesAsync()
        {
            var result = await _jokesDataService.GetRandomJokesAsync();
            Jokes = result;
        }

        public void Dispose()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion



    }
}
