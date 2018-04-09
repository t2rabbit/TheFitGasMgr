using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlareSysEfDbAndModels.Models
{
    public class RequestModelObjectT<T>
    {
        public int  TockId{ get; set; }
        public DateTime reqDt { get; set; }
        public T Info { get; set; }
    }
}
