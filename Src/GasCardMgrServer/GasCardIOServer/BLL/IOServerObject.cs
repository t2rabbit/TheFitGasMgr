using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using IOServer.BLL;
using System.Threading;
using PiPublic.Log;

namespace IOServer.BLL
{
	class IOServerObject
	{
		//
		//
		//
		#region 单件定义
        protected IOServerObject() { }
        static private IOServerObject m_pInst;
        static public IOServerObject Get()
        {
            if (m_pInst == null)
            {
                m_pInst = new IOServerObject();
            }
            return m_pInst;
        }
		#endregion


		public bool Init(int iGPRSPort)
		{
            TCPPort = iGPRSPort;

			//
			// 初始化所有需要初始化的单件类
			//
			DBMgr.Get().ReloadDBToList();
            LastStatusMgr.Get().Init();
            MemNodeValueMgr.Get().Init();
			return true;
		}

		public bool Start()
		{
			// 启动
			LogMgr.WriteInfoDefSys("启动.........");
			DevMgr.Get().Start();
			CommandOPMgr.Get().Start();
            //DevModThreadStaticMgr.Get().Start();
            

            m_pThread = new Thread(new ThreadStart(Run));
            m_pThread.IsBackground = true;
            m_bRun = true;
            m_pThread.Start();

            m_TcpServer.Port = TCPPort;
			m_TcpServer.Start();
			m_bRun = true;
			return true;
		}

		public bool Stop()
		{
            LogMgr.WriteInfoDefSys("停止.........");
			DevMgr.Get().Stop();
            CommandOPMgr.Get().Stop();
            //DevModThreadStaticMgr.Get().Stop();
            m_TcpServer.Stop();


			m_bRun = false;
            try
            {
                if (m_pThread != null)
                {
                    m_bRun = false;
                    m_pThread.Join(1000);
                    if (m_pThread.IsAlive)
                    {
                        m_pThread.Abort();
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
            finally
            {
                m_pThread = null;
            }

			return true;
		}

		public int ID { get; set; }
        public string StrEncyKey { get; set; }
        public int TCPPort { get; set; }
        private bool m_bRun;
        private Thread m_pThread;
		public bool ISRun()
		{
			return m_bRun;
		}

        private void Run()
        {
            int i = 100;
            while (m_bRun)
            {
                try
                {
                    i = 100;
                    Thread.Sleep(1000);

                    //
                    // update all newest value to db
                    //
                    MemNodeValueMgr.Get().UpdateOrInserNodeLastValToDB();

                    //
                    // updata devstatus to db
                    //
                    //DevModThreadStaticMgr.Get().UpdateMemStatusToDB();
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                }
                
                while (i-- > 0 && m_bRun)
                {
                    Thread.Sleep(1000);
                }
            }
        }

		TCPServerMgr m_TcpServer = new TCPServerMgr();
	}
}
