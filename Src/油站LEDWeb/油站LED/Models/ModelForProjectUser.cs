using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OilStationLED.Models
{
    public class ModelForProjectUser : ProjectUser
    {
        public string RefGroupName { get; set; }
        public string RefOrgName { get; set; }
        public string MgrProjectName { get; set; }
    }
}