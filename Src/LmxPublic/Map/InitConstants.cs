using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LmxPublic.Map
{
   public class InitConstants
    {
        private InitConstants() { }
        public static int InitNumber            = -1;
        public static float InitFloat           = 0F;
        public static string InitString         = string.Empty;
        public static DateTime InitDateTime     = DateTime.Now;
        public static bool InitBit              = false;
        public static decimal InitDecimal       = 0m;
        public static decimal InitDecimalNull   = -9999m;
        public static string strEntityPath = "";//System.Web.HttpContext.CurrenHQWebSys.DataFade.TMapPointt.Request.ApplicationPath + "/bin/DataFacade/";
    }
}
