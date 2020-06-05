using System;
using System.Collections.Generic;
using System.Text;

namespace TvSeries.Model
{
    public class ActorModel
    {
        public string Name { get; set; }
        public string Character { get; set; }

        public string NameCharacter { get { return Name + ":" + Character; } }
    }
}
