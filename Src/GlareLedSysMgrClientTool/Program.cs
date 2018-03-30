using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YD_PUBLIC;

namespace Property
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string strVal = ConfigHlper.GetConfig("isruncfgtool");

            if (strVal == ConstDef.strValIsRunCfg)
            {
                FormMainCfg dlg = new FormMainCfg();
                //FormCfgEx dlg = new FormCfgEx();
                dlg.ShowDialog();
            }
            else
            {
                           
                strVal = ConfigHlper.GetConfig(ConstDef.strKeyIsRunServer);
                //strValByCfg = ConfigHlper.GetConfig(ConstDef.strValIsRunServer);
                if (strVal != ConstDef.strValIsRunServer)
                {
                    //MessageBox.Show("Config file is worng, please connect to mgr");
                    return;
                }
            
                m_pMainForm = new FormMain();
                Application.Run(m_pMainForm);
            }

        }

        public static FormMain m_pMainForm;

        public static void AddDevMsg(string strMod, string strC1, string strC2, string strC3, string strLogDt, string strMsg, int iT1 = 0, int iT2 = 0, int iT3 = 0)
        {
            //LogMgr.WriteLog(strMod, strC1, strC2, strC3, strLogDt, strMsg);
            if (!m_pMainForm.IsDisposed)
            {
                m_pMainForm.BeginInvoke(new Action<string, string, string, string, string, string>(m_pMainForm.InsertIntoLogList),
                    strMod, strC1, strC2, strC3, strLogDt, strMsg);
            }
        }
    }
}
