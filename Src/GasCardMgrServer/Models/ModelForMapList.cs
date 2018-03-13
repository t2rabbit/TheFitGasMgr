using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class ModelForMapList
    {
        //
        // ForMap
        //

        public string type { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string color { get; set; }
        public string icon { get; set; }
        public ModelForOffset offset { get; set; }
        public ModelForLnglat lnglat { get; set; }
    }
}
