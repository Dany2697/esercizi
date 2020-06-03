
using System.Collections.Generic;
using System.Linq;
using TraktNet.Objects.Get.Seasons;
using TvSeries.Model;

namespace TvSeries
{
    public class SerieTvModel 
    {
        public string Title { get; set; }

        public string ImagePath { get ; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Year { get; set; }

        public IEnumerable<string> Genres { get; set; }
        public List<SeasonModel> Seasons { get; set; }




    }
       
}
