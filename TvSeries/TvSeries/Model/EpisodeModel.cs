using System;
using System.Collections.Generic;
using System.Text;

namespace TvSeries.Model
{
   public class EpisodeModel
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Overview { get; set; }
        public int Season { get; set; }
        public int Number { get; set; }
        public string TitleNumber { get { return Number + "-" + Title; } }
    }
}
