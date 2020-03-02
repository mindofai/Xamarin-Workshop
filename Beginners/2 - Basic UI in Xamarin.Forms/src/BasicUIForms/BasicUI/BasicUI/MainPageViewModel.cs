using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BasicUI
{
    public class MainPageViewModel
    {
        public ObservableCollection<Anime> Animes { get; set; }

        public MainPageViewModel()
        {

        }
    }
}
