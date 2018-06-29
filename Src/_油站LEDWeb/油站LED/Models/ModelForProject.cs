using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OilStationLED.Models
{
    public class ModelForProject:ProjectInfo
    {
        public string GroupName { get; set; }
        public string OrgName { get; set; }
    }
}