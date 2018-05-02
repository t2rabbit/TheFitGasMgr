using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OilStationLED.Models
{
    public class ModelForGasCardWithCommInfo:GasCardWithCommInfo
    {
        public string ProjectName { get; set; }
        public string GroupName { get; set; }
        public string OrgName { get; set; }

    }
}