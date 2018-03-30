using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using YD_PUBLIC.Log;
using System.Net;
using YDesmsPublicDefDll;
using System.Diagnostics;
using DBSqlite;
using System.Windows.Forms;

namespace Property.Devs
{
	class TCPPort : IPort
	{
		public void SetDBDev(GL_Dev aDev)
		{
			m_aDev = aDev;			
		}

		public bool Open()
		{
            //LogMgr.WriteLog("")
			try
			{
				if (m_tcpClient != null)
				{
					//m_tcpClient.GetStream().Dispose();
					m_tcpClient.Close();
				}

                m_tcpClient = TimeOutSocket.Connect(m_aDev.DevServerIP, (int)m_aDev.DevServerPort, 1000);
                //m_tcpClient = TimeOutSocket.Connect("127.0.0.1", (int)m_aDev.TCPPort, 1000);
			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				m_tcpClient = null;
				return false;
			}
			
			if (m_tcpClient == null)
			{
				return false;
			}
			m_tcpClient.ReceiveTimeout = 1000;
			return m_tcpClient.Connected;
		}

		public bool IsOpen()
		{            
			return (m_tcpClient!=null && m_tcpClient.Connected);
		}

		public bool Close()
		{
            if (m_tcpClient == null)
                return true;
                
            m_tcpClient.Close();            
			return true;
		}

		public byte[] Read()
		{
			if (m_tcpClient == null || !m_tcpClient.Connected)
			{
				return null;
			}
			NetworkStream stream = m_tcpClient.GetStream();				
			byte []data = new Byte[1024];
			String responseData = String.Empty;
			DateTime dtNow = DateTime.Now;
			int iRtyTime = 200;
			bool bReadAble = false;
			try
			{
				while (iRtyTime-- >0)
				{
                    if (m_tcpClient.Client.Poll(10, SelectMode.SelectRead))
                    {
                        bReadAble = true;
                        Thread.Sleep(10);
                        break;
                    }

					Thread.Sleep(10);
				}

				if (!bReadAble)
                {
					return null;
				}

				Int32 bytes = stream.Read(data, 0, data.Length);
				if (bytes <= 0)
				{
					return null;
				}

				byte[] bRecData = new byte[bytes];
				for (int i = 0; i < bytes; i++)
				{
					bRecData[i] = data[i];
				}
				//Program.AddDevMsg((int)m_aDev.ID, MsgDirect.E_READ, YD_PUBLIC.HexStrConver.Hex2String(bRecData, 0, bytes), m_aDev.Name);

               // Program.AddDevMsg(ConstDef.LOG_MOD_DEV_MSG, ConstDef.LOG_C1_DEV_READ, "", "", DateTime.Now.ToString(), BitConverter.ToString(bRecData));
				return bRecData;
			}
			catch (System.Exception ex)
            {
				return null;
			}
			finally
			{
			}
			
		}

		public bool Write(byte[] pMsg, int iOffset, int iLen)
		{
			if (m_tcpClient==null || !m_tcpClient.Connected)
			{
				Open();
			}


			if (m_tcpClient==null || !m_tcpClient.Connected)
			{
				return false;
			}

			NetworkStream stream = m_tcpClient.GetStream();
			bool bSended = true;
			try
			{
                //Program.AddDevMsg(ConstDef.LOG_MOD_DEV_MSG, ConstDef.LOG_C1_DEV_WRITE, "", "", DateTime.Now.ToString(), BitConverter.ToString(pMsg));
				
				stream.Write(pMsg, iOffset, iLen);
			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				bSended = false;
				return bSended;
			}
			//Program.AddDevMsg((int)m_aDev.ID, MsgDirect.E_WRITE, YD_PUBLIC.HexStrConver.Hex2String(pMsg, iOffset, iLen), m_aDev.Name);
			return bSended;
		}


        public bool SendOilContext(int iAddr, IList<string> lstStrings)
        {
            ClearOldReadBuf();
            IList<GLLedDefine.CardOilValEachNumAByte> lstOilVals = GLLedProtocol.MakeOilValBytesByString(lstStrings);
            byte[] bBuf = GLLedProtocol.MakeCmdLedSetOilVal(iAddr, lstOilVals);
            Write(bBuf, 0, bBuf.Length);
            Thread.Sleep(1000);
            byte[] bRead = Read();
            return GLLedProtocol.AnalyeseRecSetOilVal(bRead, iAddr);
        }


        /// <summary>
        /// 设置ID，强制设置
        /// </summary>
        /// <param name="iAddr">旧ID，可以为0</param>
        /// <param name="iNewID">新ID</param>
        /// <returns></returns>
        public bool SetID(int iAddr, int iNewID)
        {
            ClearOldReadBuf();
            byte[] bBuf = GLLedProtocol.MakeCmdLedSetID(iNewID);
            Write(bBuf, 0, bBuf.Length);
            Thread.Sleep(1000);
            byte[] bRead = Read();
            return GLLedProtocol.AnalyeseRecSetID(bRead, iNewID);
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="iAddr">卡ID</param>
        /// <param name="objCardCfg">参数详细信息</param>
        /// <returns></returns>
        public bool GetCfg(int iAddr, ref GLLedDefine.CardCfg objCardCfg)
        {
            ClearOldReadBuf();
            byte[] bBuf = GLLedProtocol.MakeCmdLedGetCfg(iAddr);
            Write(bBuf, 0, bBuf.Length);
            Thread.Sleep(1000);
            byte[] bRead = Read();
            return GLLedProtocol.AnalyeseRecGetCfg(bRead, iAddr, ref objCardCfg);
        }


        /// <summary>
        /// 设置卡的参数
        /// </summary>
        /// <param name="iAddr">卡ID</param>
        /// <param name="objCardCfg">参数</param>
        /// <returns></returns>
        public bool SetCfg(int iAddr, GLLedDefine.CardCfg objCardCfg)
        {
            ClearOldReadBuf();
            byte[] bBuf = GLLedProtocol.MakeCmdLedSetCfg(iAddr, objCardCfg);
            Write(bBuf, 0, bBuf.Length);
            Thread.Sleep(1000);
            byte[] bRead = Read();
            return GLLedProtocol.AnalyeseRecSetCardCfg(bRead, iAddr);
        }

        /// <summary>
        /// 读取油价牌的内容
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="objOilVal"></param>
        /// <returns></returns>
        public bool ReadOilVal(int iAddr, ref List<GLLedDefine.CardOilValEachNumAByte> lstOilVal)
        {
            ClearOldReadBuf();
            byte[] bBuf = GLLedProtocol.MakeCmdLedGetOilVal(iAddr);
            Write(bBuf, 0, bBuf.Length);
            Thread.Sleep(1000);
            byte[] bRead = Read();
            return GLLedProtocol.AnalyeseRecGetOilVal(bRead, iAddr, ref lstOilVal);
        }

        /// <summary>
        /// 设置油价牌卡上的小数点
        /// </summary>
        /// <param name="iAddr">ID</param>
        /// <param name="iArrDecmails">每块牌上的小数点位置（一个控制卡可以接N个显示屏）</param>
        /// <returns></returns>
        public bool SetCardDecmial(int iAddr, int[] iArrDecmails)
        {
            ClearOldReadBuf();
            byte[] bBuf = GLLedProtocol.MakeCmdLedSetDecimal(iAddr, iArrDecmails);
            Write(bBuf, 0, bBuf.Length);
            Thread.Sleep(1000);
            byte[] bRead = Read();
            return GLLedProtocol.AnalyeseRecSetDecemil(bRead, iAddr);
        }

        /// <summary>
        /// 设置油价牌卡上的小数点
        /// </summary>
        /// <param name="iAddr">ID</param>
        /// <param name="iArrDecmails">每块牌上的小数点位置（一个控制卡可以接N个显示屏）</param>
        /// <returns></returns>
        public bool GetCardDecmial(int iAddr, ref int[] iArrDecmails)
        {
            ClearOldReadBuf();
            byte[] bBuf = GLLedProtocol.MakeCmdLedGetDecimal(iAddr);
            Write(bBuf, 0, bBuf.Length);
            Thread.Sleep(1000);
            byte[] bRead = Read();
            return GLLedProtocol.AnalyeseRecGetDecmail(bRead, iAddr, ref iArrDecmails);
        }

        public bool ReadLedDotValString(int iAddr, ref string strVals)
        {
            ClearOldReadBuf();
            byte[] bBuf = GLLedProtocol.MakeCmdLedGetDecimal(iAddr);
            Write(bBuf, 0, bBuf.Length);
            Thread.Sleep(1000);
            byte[] bRead = Read();
            return GLLedProtocol.AnalyeseRecGetDecmailString(bRead, ref strVals);
        }



        /// <summary>
        /// 读取时间
        /// </summary>
        public bool ReadTime(int iAddr, ref DateTime dtRead)
        {
            ClearOldReadBuf();
            byte[] bBuf = TimeTempProtocol.MakeGetTime(iAddr);
            Write(bBuf, 0, bBuf.Length);
            Thread.Sleep(1000);
            byte[] bRead = Read();



            return GLLedProtocol.AnalyeseRecSetCardCfg(bRead, iAddr);
        }



		public bool Start()
		{
// 			if (!Open())
// 			{
// //                 Program.AddDevMsg(ConstDef.LOG_MOD_DEV_MSG, ConstDef.LOG_C1_DEV, "", "", DateTime.Now.ToString(), "连接失败" + 
// //                     m_aDev.Name);								
// 			}
// 			m_thread = new Thread(new ThreadStart(Run));
// 			m_thread.IsBackground = true;
// 			m_bRun = true;
// 			m_thread.Start();
 			return true;
		}
		public bool Stop()
		{
//            
//                         try
//                         {
//                             if (m_tcpClient != null)
//                             {
//                                 m_tcpClient.Close();
//                             }
//             
//                             if (m_thread != null)
//                             {
//                                 m_bRun = false;
//                                 m_thread.Join(1000);
//                                 if (m_thread.IsAlive)
//                                 {
//                                     m_thread.Abort();
//                                 }
//                             }
//                         }
//                         catch (System.Exception ex)
//                         {
//             
//                         }
//                         finally
//                         {
//                             m_thread = null;
//                         }
			return false;
		}
		public void OnRead()
		{			
		}

		TcpClient m_tcpClient;// = new TcpClient();	
		GL_Dev m_aDev;

		private const string c_strAllFailed = "所有都失败";
		private const string c_strOnLine = "在线";
		//
		// 
		//
		private void Run()
		{
		}

		private const string c_HandleHeat = "处理检测心跳完成";
		private const string c_Hanlder = "后台程序";

		void DelayForSecs(DateTime dtLastRun, int iSesc)
		{
			// 在计划的时间内采集一次
			TimeSpan ts = (DateTime.Now - dtLastRun);
			if (ts.TotalSeconds < iSesc)
			{
				Thread.Sleep(100);
				while (ts.TotalSeconds < iSesc)
				{
					//HandleCmd();
					ts = (DateTime.Now - dtLastRun);

					Thread.Sleep(100);

					if (!m_bRun)
						break;
				}
			}
		}


        private void ClearOldReadBuf()
        {
            if (m_tcpClient == null || !m_tcpClient.Connected)
            {
                return;
            }
            
            bool bReadAble = false;
            try
            {

                NetworkStream stream = m_tcpClient.GetStream();
                byte[] data = new Byte[1024];
                String responseData = String.Empty;
                DateTime dtNow = DateTime.Now;

                if (stream.DataAvailable)
                {
                    bReadAble = true;                        
                }

                if (!bReadAble)
                {
                    return;
                }

                Int32 bytes = stream.Read(data, 0, data.Length);
             
                LogMgr.WriteLog("接收到错乱的数据",0,  "gw", 1, DateTime.Now,  
                     0, 0, (int)m_aDev.ID, 0, 0, 0, 0, 0, "", "", 0,0,0,"",1);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Assert(false);
            }
            finally
            {
            }
        }

        Thread m_thread;
		bool m_bRun;
		
	}

	class TimeOutSocket
	{
		private static bool IsConnectionSuccessful = false;
		private static Exception socketexception;
		private static ManualResetEvent TimeoutObject = new ManualResetEvent(false);

		public static TcpClient Connect(string strIP, int iPort, int timeoutMSec)
		{
			TimeoutObject.Reset();
			socketexception = null;

			//string serverip = Convert.ToString(remoteEndPoint.Address);
			//int serverport = remoteEndPoint.Port;
			TcpClient tcpclient = new TcpClient();

			tcpclient.BeginConnect(strIP, iPort,
				new AsyncCallback(CallBackMethod), tcpclient);

			if (TimeoutObject.WaitOne(timeoutMSec, false))
			{
				if (IsConnectionSuccessful)
				{
					return tcpclient;
				}
				else
				{
					// throw socketexception;
					return null;
				}
			}
			else
			{
				tcpclient.Close();
				// throw new TimeoutException("TimeOut Exception");
				return null;
			}
		}
		private static void CallBackMethod(IAsyncResult asyncresult)
		{
			try
			{
				IsConnectionSuccessful = false;
				TcpClient tcpclient = asyncresult.AsyncState as TcpClient;

				if (tcpclient.Client != null)
				{
					tcpclient.EndConnect(asyncresult);
					IsConnectionSuccessful = true;
				}
			}
			catch (Exception ex)
			{
				IsConnectionSuccessful = false;
				socketexception = ex;
			}
			finally
			{
				TimeoutObject.Set();
			}
		}
	}
}
