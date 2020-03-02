using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAnimeList.Models
{
    public class AnimeDetailsModel : BindableBase
    {
        private int _id;

        [JsonProperty(PropertyName = "mal_id")]
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _website;

        [JsonProperty(PropertyName = "url")]
        public string Website
        {
            get => _website;
            set => SetProperty(ref _website, value);
        }

        private string _title;

        [JsonProperty(PropertyName = "title")]
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _imageSrc;

        [JsonProperty(PropertyName = "image_url")]
        public string ImageSrc
        {
            get => _imageSrc;
            set => SetProperty(ref _imageSrc, value);
        }


        private string _synopsis;

        [JsonProperty(PropertyName = "synopsis")]
        public string Synopsis
        {
            get => _synopsis;
            set => SetProperty(ref _synopsis, value);
        }

        private double _rating;

        [JsonProperty(PropertyName = "score")]
        public double Rating
        {
            get => _rating;
            set => SetProperty(ref _rating, value);
        }

        private DateTime? _startDate;

        [JsonProperty(PropertyName = "start_date")]
        public DateTime? StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        } 

        private DateTime? _endDate;

        [JsonProperty(PropertyName = "end_date")]
        public DateTime? EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }
    }
}
