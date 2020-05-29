using System;
using System.Collections.Generic;
using System.Text;

namespace TvSeries.Model
{
    public class PageModel
    {
        public List<SerieTvModel> Items { get; set; }

        public PageModel(List<SerieTvModel> serieTvs) {
            Items = serieTvs;
        
        }
    }
}
