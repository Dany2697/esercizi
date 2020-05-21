
using System.Collections.Generic;
using System.Linq;

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
       


    }
       
}
