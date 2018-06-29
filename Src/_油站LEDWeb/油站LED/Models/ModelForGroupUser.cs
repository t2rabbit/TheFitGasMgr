using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OilStationLED.Models
{
    public class ModelForGroupUser:GroupUser
    {
        public string MgrGroupName { get; set; }
        public string RefOrgName { get; set; }
    }
}