using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAnimeList.Models
{
    public class AnimeDetailsModel : BindableBase
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _website;
        public string Website
        {
            get => _website;
            set => SetProperty(ref _website, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _imageSrc;
        public string ImageSrc
        {
            get => _imageSrc;
            set => SetProperty(ref _imageSrc, value);
        }

        private string _synopsis;
        public string Synopsis
        {
            get => _synopsis;
            set => SetProperty(ref _synopsis, value);
        }

        private double _rating;
        public double Rating
        {
            get => _rating;
            set => SetProperty(ref _rating, value);
        }

        private string _startDate;
        public string StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private string _endDate;
        public string EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }
    }
}
