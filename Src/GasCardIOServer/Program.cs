using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace IOServer
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
// 
// // 			FormCfg dlg = new FormCfg();
// // 			dlg.ShowDialog();
//             System.Diagnostics.Process process1 = new System.Diagnostics.Process();
//             process1.StartInfo.FileName = "DBConfig.exe";
//             //该程序使用最小化运行  
//             process1.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
//             //开始进程  
//             process1.Start();
//             //设置等待关联进程退出的时间，并在该段时间结束前或该进程退出前，  
//             //阻止当前线程执行。  
//             //参数可指定等待时间 无参数就是无限等待  
//             process1.WaitForExit(); 


			m_pMainForm = new FormMain();
			Application.Run(m_pMainForm);
		}

		public static FormMain m_pMainForm;

// 		public static void AddDevMsg(MsgDirect iDirect, string strMsg, string strDevName)
// 		{
// 			if (!m_pMainForm.IsDisposed)
// 			{
// 				m_pMainForm.BeginInvoke(new Action<MsgDirect, string, string>(m_pMainForm.InsertDevCmd), iDirect, strMsg, strDevName);
// 			}
// 		}
// 
//         public static void AddDCServeqrMsg(MsgDirect iDirect, string strMsg, string strDevName)
//         {
//             if (!m_pMainForm.IsDisposed)
//             {
//                 m_pMainForm.BeginInvoke(new Action<MsgDirect, string, string>(m_pMainForm.InsertDevCmd), iDirect, strMsg, strDevName);
//             }
//         }

        public static void AddLogToMainFrom(string strMsg, string strType1, string strType2)
        {
            if (!m_pMainForm.IsDisposed)
            {
                m_pMainForm.BeginInvoke(new Action<string, string, string>(m_pMainForm.InsertLogMsgToFrom), 
                    strMsg, strType1, strType2);
            }
        }
        public static void Restart()
        {
            if (!m_pMainForm.IsDisposed)
            {
                m_pMainForm.BeginInvoke(new Action<int>(m_pMainForm.Restart), 0);
            }
        }

	}

	public enum MsgDirect
    {
        E_NONE = 0,
        E_READ = 1,
		E_WRITE = 2
	};
}
