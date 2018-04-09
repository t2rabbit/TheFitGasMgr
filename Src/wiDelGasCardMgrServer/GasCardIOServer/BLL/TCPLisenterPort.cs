using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using PiPublic.Log;
using Models;
using System.Runtime.InteropServices;

namespace IOServer.BLL
{
	class TCPLisenterPort : IPort
	{
        int m_iTimeout = 0;
        TcpClient m_tcpClient;

		public TCPLisenterPort()
		{
			m_iTimeout = CfgMgr.GetGPRSTimeout();
		}

		public override bool _Open()
		{
			return (m_tcpClient != null && m_tcpClient.Connected);
		}

        public override bool _IsOpen()
		{
			return (m_tcpClient != null && m_tcpClient.Connected);
		}
        public override bool _Close()
		{
			m_tcpClient.Close();
			return true;
		}
      
        public override byte[] _Read(int iTimeout)
        {
            int iRtyTime = iTimeout;
            if (iTimeout == 0)
            {
                iRtyTime = m_iTimeout;
            }
			if (m_tcpClient == null || !m_tcpClient.Connected)
			{
				return null;
			}
			NetworkStream stream = m_tcpClient.GetStream();
			byte[] data = new Byte[1024];
			String responseData = String.Empty;
			DateTime dtNow = DateTime.Now;
			bool bReadAble = false;
			try
			{
				while (iRtyTime > 0)
				{
					iRtyTime -= 10;
                    if (m_tcpClient.Client.Poll(10, SelectMode.SelectRead))
                    {
                        bReadAble = true;
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
                    _Close();
                    
                    return null;
                }


				byte[] bRecData = new byte[bytes];
                for (int i = 0; i < bytes; i++ )
                {
                    bRecData[i] = data[i];
                }

				if (gwPort != null)
				{
					Program.AddDevMsg(MsgDirect.E_READ, BitConverter.ToString(bRecData, 0, bytes), gwPort.Name);
				}

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

        public override bool _Write(byte[] pMsg, int iOffset, int iLen)
		{
			if (m_tcpClient == null || !m_tcpClient.Connected)
			{                
				_Open();
			}

			if (m_tcpClient == null || !m_tcpClient.Connected)
			{
                m_bRun = false;
				return false;
			}
				
			bool bSended = true;
			try
			{
				NetworkStream stream = m_tcpClient.GetStream();
				stream.Write(pMsg, iOffset, iLen);
			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				bSended = false;
				return bSended;
			}
			if (gwPort != null)
			{
				Program.AddDevMsg(MsgDirect.E_WRITE,
                    BitConverter.ToString(pMsg, iOffset, iLen), gwPort.Name);
			}
			return bSended;
		}

        public override void _OnRead()
		{

		}


        public override void _ClearBuf()
        {
            if (m_tcpClient == null || !m_tcpClient.Connected)
            {
                return;
            }

            bool bReadAble = false;
            try
            {

                NetworkStream stream = m_tcpClient.GetStream();
                stream.Flush();
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

                Int32 bytes = 0;
                bytes = stream.Read(data, 0, 1024);
                while (bytes > 0)
                {
                    bytes = stream.Read(data, 0, 1024);
                }

                LogMgr.WriteErrorDefSys("接收到错乱的数据" + "gw " + DateTime.Now +
                     "dev id: " + (int)gwPort.ID);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Assert(false);
            }
            finally
            {
            }
        }


		public TcpClient TcpClient
		{
			set
			{
				m_tcpClient = value;
			}
		}

        public bool IsGwayInfoCfgInDB()
        {
            byte[] bRec = _Read(CfgMgr.GetGPRSSNTimeout());
            if (bRec == null || bRec.Length == 0)
            {
                LogMgr.WriteErrorDefSys("tcp 客户端没有收到身份");
                return false;
            }

            if (bRec.Length != 10 || bRec[0] != 0X33 || bRec[9] != 0x44)
            {
                LogMgr.WriteErrorDefSys("tcp 客户端收到错误身份分析");
                return false;
            }

            byte[] bSn = new byte[8];
            for(int i=1; i<=8;i++)
            {
                bSn[i-1] = bRec[i];
            }
            string strName = new ASCIIEncoding().GetString(bSn);
            bool bFinded = false;
            try
            {
                foreach (GatewayModel gateMod in DBMgr.Get().LstPortGaweway)
                {
                    //int iPanDev = Convert.ToInt32("0x" + aDev.PainMasterAdder, 16);
                    if (strName == gateMod.ProtocolSN)
                    {
                        bFinded = true;

                        SetGwayInfo(gateMod);
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                LogMgr.WriteErrorDefSys("tcp 客户端收到身份, 分析出错");
                return false;
            }

            if (!bFinded)
            {
                LogMgr.WriteErrorDefSys("tcp 客户端收到身份, 分析出错");
                // 
                // 测试使用第一个网关
                //
                SetGwayInfo(DBMgr.Get().LstPortGaweway.FirstOrDefault());
                return true;

                return false;
            }

            return bFinded;
        }
	}
}
