using System;
using System.Collections.Generic;
using System.Text;
using TraktNet.Objects.Get.Episodes;
using TraktNet.Objects.Get.Seasons;

namespace TvSeries.Model
{
    public class SeasonModel 
    {
       
        public string Title { get ; set ; }
       
        public List<ITraktEpisode> Episodes { get; set; }

       
    }
}
