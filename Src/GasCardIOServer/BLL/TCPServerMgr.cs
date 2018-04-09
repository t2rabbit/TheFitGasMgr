using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using PiPublic.Log;

namespace IOServer.BLL
{
	class TCPServerMgr
	{
		public int Port { get; set; }
		private TcpListener m_tcpServer;
		private Thread m_pThread;
		private bool m_bRun;
		private IList<TCPEndPort> lstPortClients = new List<TCPEndPort>();

        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <returns></returns>
		public bool Start()
		{
			try
			{
				m_tcpServer = new TcpListener(new System.Net.IPEndPoint(0, Port));
				m_tcpServer.Server.Blocking = false;
				m_tcpServer.Start();
				m_tcpServer.Server.Blocking = false;
				m_pThread = new Thread(new ThreadStart(Run));
				m_pThread.IsBackground = true;
				m_bRun = true;
				m_pThread.Start();
				return true;
			}
			catch (System.Exception ex)
			{
				LogMgr.WriteErrorDefSys("tcp server 启动失败， 端口号: " + Port);                
				return false;
			}
			
		}

		public void Stop()
		{
			try
			{
				m_bRun = false;
				m_pThread.Join(1000);

				m_tcpServer.Stop();
			}
			catch (System.Exception ex)
			{
				
			}

		}

		private void Run()
		{
            // todo 修改成异步模式
			while (m_bRun)
			{
				try
				{
                    if (!m_tcpServer.Pending())
                    {
                        Thread.Sleep(10);
                        continue;
                    }
					TcpClient aTcpClient = m_tcpServer.AcceptTcpClient();

                    Program.AddLogToMainFrom("TCP连接", aTcpClient.Client.RemoteEndPoint.ToString(), aTcpClient.Client.LocalEndPoint.ToString());
					aTcpClient.Client.Blocking = true;
					TCPEndPort aNewPort = new TCPEndPort();					
					aNewPort.TcpClient = aTcpClient;
                    if (aNewPort.IsGwayInfoCfgInDB())
					{
						ClearOldTcpLisenterPort((int)aNewPort.GwayInfo.ID);
						lstPortClients.Add(aNewPort);
                        aNewPort.Start();

                        LastStatusMgr.Get().UpdateGwStatusToMem(aNewPort.GwayInfo.ID, LastStatusInfo.EStatus.ESOnLine);
					}
					else
					{
						aTcpClient.Close();
					}
				}
				catch (System.Exception ex)
				{
					
				}
				
			}
		}


		private void ClearOldTcpLisenterPort(int iDevID)
		{
			for (int i=0; i<lstPortClients.Count; i++)
			{
                TCPEndPort tp = lstPortClients[i];
				if (tp.GwayInfo.ID == iDevID)
				{
                    LogMgr.WriteDebugDefSys("以前有一个连接，现在删除... :" + tp.GwayInfo.Name);
					tp.Stop();
					lstPortClients.RemoveAt(i);
                    return;
				}
			}
		}
	}
}
