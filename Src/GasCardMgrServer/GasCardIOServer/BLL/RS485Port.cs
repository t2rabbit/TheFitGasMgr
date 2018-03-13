using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO.Ports;

namespace IOServer.BLL
{

    //class RS485Port : IPort
    //{
    //    int m_iTimeout = 0;

    //    public RS485Port()
    //    {
    //        m_iTimeout = CfgMgr.GetTimeout();
    //    }

    //    public override bool _Open()
    //    {
    //        try
    //        {
    //            m_serialPort.PortName = m_aDev.CommPort;
    //            m_serialPort.BaudRate = (int)m_aDev.Baud;
    //            m_serialPort.DataBits = (int)m_aDev.DataBit;
    //            m_serialPort.StopBits = StopBits.One;//(m_aDev.StopBit == 0 ?  : m_aDev.StopBit == 2 ? StopBits.Two : StopBits.OnePointFive);
    //            m_serialPort.ReadTimeout = (int)m_aDev.TimeOut;
    //            m_serialPort.Parity = (Parity)m_aDev.Parity;
    //            m_serialPort.WriteTimeout = 1000;
    //            m_serialPort.Handshake = Handshake.None;
    //            m_serialPort.Encoding = Encoding.ASCII;
    //            m_serialPort.RtsEnable = true;
           
    //            m_serialPort.Open();
    //            if (!IsDevCfgInDB())
    //            {
    //                _Close();

    //                FileLog.WriteLog("Open fiale");
    //                return false;
    //            }

    //            return m_serialPort.IsOpen;
    //        }
    //        catch (System.Exception ex)
    //        {

    //            System.Diagnostics.Debug.WriteLine(ex.Message);
    //            return false;
    //        }
            
    //    }

    //    public override bool _IsOpen()
    //    {
    //        return m_serialPort.IsOpen;
    //    }
    //    public override bool _Close()
    //    {
    //        m_serialPort.Close();
    //        return true;
    //    }


    //    public override byte[] _Read()
    //    {
    //        try
    //        {
    //            int iBytesToRead = m_serialPort.BytesToRead;
    //            int iRtyMS = 0;
    //            while (true)
    //            {
    //                if (iBytesToRead > 0)
    //                {
    //                    break;
    //                }

    //                iRtyMS += 50;
    //                if (iRtyMS > m_aDev.TimeOut)
    //                {
    //                    break;
    //                }
    //                Thread.Sleep(50);
    //                iBytesToRead = m_serialPort.BytesToRead;
    //            }

    //            if (iBytesToRead <= 0)
    //            {
    //                return null;
    //            }

    //            byte[] pRecBuf = new byte[iBytesToRead];
    //            m_serialPort.Read(pRecBuf, 0, iBytesToRead);
    //            if (m_aDev != null)
    //            {
    //                Program.AddDevMsg(MsgDirect.E_READ, BitConverter.ToString(pRecBuf, 0, pRecBuf.Length), m_aDev.Name);
    //            }

    //            FileLog.WriteLog("READ:" + BitConverter.ToString(pRecBuf, 0, iBytesToRead));
    //            return pRecBuf;
    //        }
    //        catch (System.Exception ex)
    //        {
    //            FileLog.WriteLog("read error");
    //            FileLog.WriteLog(ex.Message);

    //            return null;
    //        }
    //    }

    //    public override bool _Write(byte[] pMsg, int iOffset, int iLen)
    //    {
    //        try
    //        {
    //            if (m_aDev != null)
    //            {
    //                FileLog.WriteLog("WRITE:" + BitConverter.ToString(pMsg, iOffset, iLen));
    //                Program.AddDevMsg(MsgDirect.E_WRITE, BitConverter.ToString(pMsg, iOffset, iLen), m_aDev.Name);
    //            }
    //            m_serialPort.Write(pMsg, iOffset, iLen);
    //            return true;
    //        }
    //        catch (System.Exception ex)
    //        {
    //            return false;
    //        }            
    //    }

    //    public override void _OnRead()
    //    {

    //    }


    //    public override void _ClearBuf()
    //    {
    //        try
    //        {
    //            m_serialPort.DiscardInBuffer();
    //        }
    //        catch (System.Exception ex)
    //        {            	
    //        }            
    //    }


    //    private bool IsDevCfgInDB()
    //    {
    //        // 
    //        byte[] bCmd = WLC1301Protocol.MakeGetPanIDCmd();
    //        _Write(bCmd, 0, bCmd.Length);
    //        byte[] bRec = _Read();
    //        if (bRec == null || bRec.Length == 0)
    //        {
    //            LogMgr.WriteLog("tcp 客户端没有收到身份");
    //            return false;
    //        }
    //        if (bRec.Length != 10 || bRec[0] != 0xab || bRec[9] != 0xba)
    //        {
    //            LogMgr.WriteLog("tcp 客户端收到错误身份分析");
    //            return false;
    //        }

    //        int iPanid = ((bRec[2] << 8) + bRec[3]);
    //        bool bFinded = false;
    //        foreach (cnwlcs_PortDdev aDev in DBMgr.Get().ListDevPort)
    //        {
    //            try
    //            {
                
    //                if (aDev.PainMasterAdder == null || aDev.PainMasterAdder=="")
    //                {
    //                    continue;
    //                }

    //                int iPanDev = Convert.ToInt32("0x" + aDev.PainMasterAdder, 16);
    //                if (iPanDev == iPanid)
    //                {
    //                    bFinded = true;

    //                    SetDBDev(aDev);
    //                    break;
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                LogMgr.WriteLog("tcp 客户端收到身份, 分析出错");
    //                continue;
    //            }

    //        }

    //        if (!bFinded)
    //        {
    //            LogMgr.WriteLog("tcp 客户端收到身份, 分析出错");
    //            return false;
    //        }

    //        return bFinded;
    //    }


    //    //
    //    // port
    //    //
    //    SerialPort m_serialPort = new SerialPort();
    //}
}
