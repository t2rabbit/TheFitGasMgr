using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OilStationLED
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LoadStartFun();
        }


        /// <summary>
        /// 网站启动的时候执行这个方法
        /// </summary>
        public void LoadStartFun()
        {
            //TcpServerForGPRSDev.Get().Port = 7804;
            //MemCfgInfo.MemDbMgr.Get().Load();
            //if (!TcpServerForGPRSDev.Get().Start())
            //{
            //    this.Invoke((MethodInvoker)delegate
            //    {
            //        timerRestartTcpServer.Enabled = true;
            //    });
            //}
        }
    }
}