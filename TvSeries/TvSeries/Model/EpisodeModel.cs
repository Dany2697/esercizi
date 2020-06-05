using FanartTv.TV;
using System;
using System.Collections.Generic;
using System.Text;

namespace TvSeries.Model
{
    public class EpisodeModel
    {
        public string Title { get; set; }
        public string Overview { get; set; }
        public int? Season { get; set; }
        public int? Number { get; set; }
        public List<ActorModel> Actors { get; set; }
        public int? Runtime { get; set; }
        public DateTime? Aired { get; set; }
        public string Show { get; set; }

        public string TitleNumber { get { return Number + "-" + Title; } }
    }
}
