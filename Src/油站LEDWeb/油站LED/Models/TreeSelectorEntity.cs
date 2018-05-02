using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OilStationLED.Models
{
    public class TreeSelectorEntity
    {
        public string id
        {
            get;
            set;
        }
        public string text
        {
            get;
            set;
        }
        public string state
        {
            get;
            set;
        }
        public string iconCls
        {
            get;//{ return "icon-save"; }
            set;// { value = ""; }
        }
        public Object attributes
        {
            get;
            set;
        }
    }
}