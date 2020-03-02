using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAnimeList.Models
{
    public class AnimeListModel
    {
        [JsonProperty(PropertyName = "results")]
        public List<AnimeDetailsModel> Animes { get; set; }
    }
}
