using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using PiPublic.Log;

namespace GlareSysDataCenter.CommRW
{
	class TcpServerForGPRSDev
	{


        //
        // 单件支持
        //
        #region 单件支持
        private static TcpServerForGPRSDev m_pInst;
        protected TcpServerForGPRSDev()
        {
        }
        static public TcpServerForGPRSDev Get()
        {
            if (m_pInst == null)
            {
                m_pInst = new TcpServerForGPRSDev();                
            }
            return m_pInst;
        }
        #endregion 单件支持

		public int Port { get; set; }
		private IList<TcpClient> m_clients = new List<TcpClient>();
		private TcpListener m_tcpServer;
		private Thread m_pThread;
		private bool m_bRun;
		private IList<TCPLisenterPort> m_TcpPorts = new List<TCPLisenterPort>();

		public bool Start()
		{
			try
			{
                LogMgr.WriteInfoDefSys("listen tcp port is: " + Port);
				m_tcpServer = new TcpListener(new System.Net.IPEndPoint(0, Port));                
                m_tcpServer.Server.Blocking = false;
                m_tcpServer.Start();
                m_tcpServer.Server.Blocking = false;
                LogMgr.WriteInfoDefSys("linstening...");
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
				foreach (TCPLisenterPort client in m_TcpPorts)
				{
                    client.Close();
					//client.Stop();
				}
				m_tcpServer.Stop();
			}
			catch (System.Exception ex)
			{
				
			}

		}

		private void Run()
		{
            LogMgr.WriteInfoDefSys("tcpserver run...");
            while (m_bRun)
			{				
				try
				{
                    if (!m_tcpServer.Pending())
                    {
                        Thread.Sleep(100);
                        continue;
                    }
					TcpClient aTcpClient = m_tcpServer.AcceptTcpClient();
					string strInfo = string.Format("有客户端连接，客户端IP：{0}", aTcpClient.Client.RemoteEndPoint.ToString() );										
                    LogMgr.WriteInfoDefSys(strInfo);
					aTcpClient.Client.Blocking = true;
					TCPLisenterPort aNewPort = new TCPLisenterPort();
                    aNewPort.TCPCLIENT = aTcpClient;

                    if (aNewPort.Start())
                    {
                        LogMgr.WriteInfoDefSys("客户端配置信息正确，GPRS模块运行 id:" + 
                            aNewPort._commDev.cardInfo.Id +", name:" + aNewPort._commDev.cardInfo.Name );
                        ClearOldTcpLisenterPort((int)aNewPort._commDev.cardInfo.Id);
                        m_TcpPorts.Add(aNewPort);
                    }
                    else
                    {
                        LogMgr.WriteInfoDefSys("客户端配置信息错误，GPRS模块失败, 可能是非法连接");
                        aTcpClient.Close();
                    }
                }
                catch (System.InvalidOperationException sex)
                {
                    Thread.Sleep(100);
                }
                catch (System.Net.Sockets.SocketException sex)
                {
                    Thread.Sleep(100);
                }
				catch (System.Exception ex)
				{
					Thread.Sleep(100);
				}				
			}

			LogMgr.WriteInfoDefSys("系统关闭");
		}


		private void ClearOldTcpLisenterPort(int iDevID)
		{
			foreach (TCPLisenterPort tp in m_TcpPorts)
			{
				if (tp._commDev.cardInfo.Id == iDevID)
				{
//                     DBMgr.Get().AddDBLog("moxa", "系统有旧的连接:ip" +
//                         tp.TCPCLIENT.Client.RemoteEndPoint.ToString() + "dev:" + tp.m_aDev.Name, 0, 0);
					//tp.Stop();
                    tp.Close();
					m_TcpPorts.Remove(tp);
					return;
				}
			}
		}

        public bool GetDevIsConnected(int iDevID)
        {
            try
            {
                foreach (TCPLisenterPort tp in m_TcpPorts)
                {
                    if (tp._commDev.cardInfo.Id == iDevID)
                    {
                        if (tp.DTLastCommTime.AddSeconds(30) < DateTime.Now)
                        {
                            LogMgr.WriteInfoDefSys("test is connect idevid:" + iDevID);
                            if (!tp.TestConnected())
                            {
                                tp.Close();
                                ClearOldTcpLisenterPort((int)tp._commDev.cardInfo.Id);
                                return false;
                            }
                        }
                        return true;
                    }
                }
            }
            catch (System.Exception ex)
            {
            	
            }
            
                return false;
        }

        public TCPLisenterPort GetDevConnectedTcpClient(int iDevID)
        {
            foreach (TCPLisenterPort tp in m_TcpPorts)
            {
                if (tp._commDev.cardInfo.Id == iDevID)
                {
                    return tp;
                }
            }
            return null;
        }
	}
}
