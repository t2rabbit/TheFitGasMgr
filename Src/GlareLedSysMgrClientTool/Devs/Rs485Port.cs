using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using YD_PUBLIC.Log;
using DBSqlite;
using YDesmsPublicDefDll;

namespace Property.Devs
{
 	class Rs485Port : IPort
 	{
 		public void SetDBDev(GL_Dev aDev)
 		{
 			m_aDev = aDev;
 		}
 
 		public bool  Open()
 		{
            try
            {

                if (m_serialPort.IsOpen)
                {
                    m_serialPort.Close();
                }
            }
            catch (System.Exception ex)
            {
            	
            }
 			m_serialPort.PortName = m_aDev.SerialPort;
 			m_serialPort.BaudRate = (int)m_aDev.SerialBaud;
 			m_serialPort.DataBits = 8;
            m_serialPort.StopBits = StopBits.One;
 			m_serialPort.ReadTimeout = 1000;
 			m_serialPort.Parity = Parity.None;
  			m_serialPort.WriteTimeout = 1000;			
  			m_serialPort.Handshake = Handshake.None; 			
 			m_serialPort.RtsEnable = true;           
 
 			bool bOpen  = true;
 
 			try
 			{
 				m_serialPort.Open();
 			}
 			catch (System.Exception ex)
 			{
 				//System.Diagnostics.Debug.WriteLine(ex.Message);
                FileLog.WriteLog("comm open ex:" + ex.Message);
 				bOpen = false;
 			}
 			
 			System.Diagnostics.Debug.Assert(bOpen);
 
 
 			return m_serialPort.IsOpen;
 		}
 
 		public bool IsOpen()
 		{
 			return m_serialPort.IsOpen;
 		}
 		public bool Close()
 		{
 			m_serialPort.Close();
 			return true;
 		}
 
 
 		public byte[] Read()
 		{
            try
            {
                int iBytesToRead = m_serialPort.BytesToRead;
                int iRtyMS = 0;
                while (true)
                {
                    if (iBytesToRead > 0)
                    {
                        break;
                    }

                    iRtyMS += 50;
                    if (iRtyMS > m_aDev.Timeout)
                    {
                        break;
                    }
                    Thread.Sleep(50);
                    iBytesToRead = m_serialPort.BytesToRead;
                }

                if (iBytesToRead <= 0)
                {
                    return null;
                }

                byte[] pRecBuf = new byte[iBytesToRead];
                m_serialPort.Read(pRecBuf, 0, iBytesToRead);
                if (pRecBuf[iBytesToRead - 1] != GLLedDefine.btCmdEnd)
                {
                    Thread.Sleep(100);
                    int iAppend = m_serialPort.BytesToRead;
                    if (iAppend > 0)
                    {
                        byte[] pRecApp = new byte[iAppend];
                        m_serialPort.Read(pRecApp, 0, iAppend);

                        byte[] bNew = new byte[iBytesToRead + iAppend];
                        int ioffset = 0;
                        for (int i = 0; i < iBytesToRead; i++)
                        {
                            bNew[ioffset++] = pRecBuf[i];
                        }

                        for (int i = 0; i < iAppend; i++)
                        {
                            bNew[ioffset++] = pRecApp[i];
                        }

                        pRecBuf = bNew;

                        FileLog.WriteLog("-- append -- len ");
                    }

                }


                if (pRecBuf != null)
                {
                    String strRec = BitConverter.ToString(pRecBuf);
                    FileLog.WriteLog("rec:" + strRec);
                }

                return pRecBuf;
            }
            catch (System.Exception ex)
            {
                return null;
            }
 			
 		}
 
 		public bool Start()
 		{
 			return true;
 			
 		}
 
 		public bool Stop()
 		{
 			return false;
 		}
 
 
 		public bool Write(byte[] pMsg, int iOffset, int iLen)
 		{
            if (!IsOpen())
            {
                Open();
            }
            if (!IsOpen())
            {
                return false;
            }
 			m_serialPort.Write(pMsg, iOffset, iLen);
 			return false;
 		}
 		
        public void OnRead()
 		{
 			
 		}
 
 		//
 		// port
 		//
 		SerialPort m_serialPort = new SerialPort();
 		GL_Dev m_aDev;
 		
 
        public bool SendOilContext(int iAddr, IList<string> lstStrings)
        {
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
            byte[] bBuf = GLLedProtocol.MakeCmdLedGetDecimal(iAddr);
            Write(bBuf, 0, bBuf.Length);
            Thread.Sleep(1000);
            byte[] bRead = Read();
            return GLLedProtocol.AnalyeseRecGetDecmail(bRead, iAddr, ref iArrDecmails);
        }

        public bool ReadLedDotValString(int iAddr, ref string strVals)
        {
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
            byte[] bBuf = TimeTempProtocol.MakeGetTime(iAddr);
            Write(bBuf, 0, bBuf.Length);
            Thread.Sleep(1000);
            byte[] bRead = Read();
            return GLLedProtocol.AnalyeseRecSetCardCfg(bRead, iAddr);
        }
 	}
}
