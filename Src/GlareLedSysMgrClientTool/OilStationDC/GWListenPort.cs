using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using YD_PUBLIC.Log;
using YDesmsPublicDefDll;

namespace Property
{
    class GWListenPort
    {
        public int Port { get; set; }        
        private TcpListener m_tcpServer;
        private Thread m_pThread;
        private bool m_bRun;
        public IList<GWTcpClientPoint> m_TcpPorts = new List<GWTcpClientPoint>();

        private int m_iCommObjAppThreadID = 0;
        public GWListenPort()
        {

        }

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
                LogMgr.WriteLog("tcp server 启动失败， 端口号: " + Port);
                return false;
            }

        }

        public void Stop()
        {
            
            m_bRun = false;
            m_pThread.Join(1000);
            
            if (m_pThread.IsAlive)
            {
                try
                {
                    m_pThread.Abort();
                }
                catch (System.Exception ex)
                {
                	
                }            
            }

            foreach (GWTcpClientPoint client in m_TcpPorts)
            {
                client.Stop();
            }
            m_tcpServer.Stop();
            

        }

        private void Run()
        {
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
                    string strInfo = "有客户端连接，客户端IP：" + aTcpClient.Client.RemoteEndPoint.ToString();
                    LogMgr.WriteLog(strInfo);
                    
//                     int keepAlive = -1744830460; // SIO_KEEPALIVE_VALS
//                     byte[] inValue = new byte[] { 1, 0, 0, 0, 0x20, 0x4e, 0, 0, 0x20, 0x4e, 0, 0 }; //True, 20 秒, 2 秒
//                     aTcpClient.Client.IOControl(IOControlCode.KeepAliveValues, inValue, null);

                    aTcpClient.Client.Blocking = true;                    
                    GWTcpClientPoint aNewPort = new GWTcpClientPoint();
                    aNewPort.TCPCLIENT = aTcpClient;
                    if (aNewPort.Start())
                    {
                        ClearOldTcpLisenterPort((int)aNewPort.m_org.ID);
                        m_TcpPorts.Add(aNewPort);
                    }
                    else
                    {
                        strInfo = "主动断开连接，客户端IP：" + aTcpClient.Client.RemoteEndPoint.ToString();
                        //Program.AddDevMsg(ConstDef.strLogDCPortMod, "","","", DateTime.Now.ToString(), strInfo);                        
                        FileLog.WriteLog(strInfo);
                        aTcpClient.Close();
                    }
                }
                catch (System.InvalidOperationException sex)
                {
                    Thread.Sleep(100);
                }
                catch (System.Net.Sockets.SocketException sex)
                {
#if DEBUG
                    Thread.Sleep(5000);
#endif
                    Thread.Sleep(100);
                }
                catch (System.Exception ex)
                {
                    Thread.Sleep(100);
                }

                //
                // 添加心跳
                //
                try
                {
                    string strKey = MemcachedObjDefine.StrKeyCommObjectIDBase + m_iCommObjAppThreadID;
                    MemcachedCommMsgObjJson aStat = new MemcachedCommMsgObjJson()
                    {
                        id = m_iCommObjAppThreadID,
                        updatetime = DateTime.Now,
                        updatestatus = "1",
                        updatemsg = "ONline"
                    };
                }
                catch (System.Exception ex)
                {
                	
                }
            }

            LogMgr.WriteLog("系统关闭");
        }


        private void ClearOldTcpLisenterPort(int iGwid)
        {
            foreach (GWTcpClientPoint tp in m_TcpPorts)
            {
                if (tp.m_org.ID == iGwid)
                {
                    Program.AddDevMsg(ConstDef.strLogDCPortMod, "","","",DateTime.Now.ToString(), "系统有旧的连接:ip" +
                            tp.TCPCLIENT.Client.RemoteEndPoint.ToString() + "gate:" + 
                            tp.m_org.Name);

                    tp.Stop();
                    m_TcpPorts.Remove(tp);
                    return;
                }
            }
        }



        public void RemoveOldTcpLisenterPort(int iGwid)
        {
            foreach (GWTcpClientPoint tp in m_TcpPorts)
            {
                if (tp.m_org.ID == iGwid)
                {
                    Program.AddDevMsg(ConstDef.strLogDCPortMod, "", "", "", DateTime.Now.ToString(), "系统有旧的连接:ip" +
                            tp.TCPCLIENT.Client.RemoteEndPoint.ToString() + "gate:" +
                            tp.m_org.Name);

                    m_TcpPorts.Remove(tp);
                    return;
                }
            }
        }

        public bool IsGWConnected(int iGwID)
        {
            foreach (GWTcpClientPoint tp in m_TcpPorts)
            {
                if (tp.m_org.ID == iGwID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
