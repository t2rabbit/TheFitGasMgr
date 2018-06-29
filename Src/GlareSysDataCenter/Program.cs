using PiPublic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlareSysDataCenter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程的异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ApplicationThreadException);
            //处理非UI线程的异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomainUnhandledException);
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LogMgr.InitFileTraceLog();

            Application.Run(new FormMain());
        }

        static void ApplicationThreadException(object sender, System.Threading.ThreadExceptionEventArgs ee)
        {
            LogMgr.WriteErrorDefSys(ee.Exception.InnerException.Message);
            LogMgr.WriteErrorDefSys(ee.Exception.InnerException.StackTrace);
        }

        static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs ee)
        {
            Exception e = ee.ExceptionObject as Exception;
            LogMgr.WriteErrorDefSys(e.InnerException.Message);
            LogMgr.WriteErrorDefSys(e.InnerException.StackTrace);
        }
    }
}
