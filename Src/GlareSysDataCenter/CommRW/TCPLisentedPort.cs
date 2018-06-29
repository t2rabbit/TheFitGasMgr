using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using PiPublic.Log;
using GLLedPublic;
using PiPublic;


namespace GlareSysDataCenter.CommRW
{
    // 接收到后创建的客户端
    class TCPLisentedPort
    {
        bool _bRun = false;
        private Thread _thread;

        bool m_bGprs = false;
        int iClientID = 0;
        static public int curID = 0;
        public DateTime DTLastCommTime
        {
            get;
            set;
        }

        public bool Stop()
        {
            _commDev.CurStatus = 0;

            PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyCardStatus + _commDev.cardInfo.Id, "0");

            _bRun = false;
            if (_thread != null)
            {
                if (!_thread.Join(3000))
                {
                    try
                    {
                        _thread.Abort();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            _thread = null;
            return true;
        }

        public TCPLisentedPort()
        {
            DTLastCommTime = DateTime.Now;
            iClientID = curID++;
        }
        public void SetDBDev(MemCfgInfo.MemCardWithCommDev aDev)
        {
            _commDev = aDev;
        }

        public bool Open()
        {
            return (m_tcpClient != null && m_tcpClient.Connected);
        }

        public bool IsOpen()
        {
            return (m_tcpClient != null && m_tcpClient.Connected);
        }
        public bool Close()
        {
            m_tcpClient.Close();
            return true;
        }


        //
        // bError in out in为TRUE表示测试
        //
        public byte[] Read(out bool bError)
        {
            bError = false;
            if (m_tcpClient == null || !m_tcpClient.Connected)
            {
                return null;
            }
            NetworkStream stream = m_tcpClient.GetStream();
            byte[] data = new Byte[1024];
            String responseData = String.Empty;
            DateTime dtNow = DateTime.Now;
            int iRtyTime = 4000;
            if (bError == true)
            {
                iRtyTime = 1;
            }
            bool bReadAble = false;
            try
            {
                while (iRtyTime > 0)
                {
                    iRtyTime -= 10;
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
                    Close();
                    bError = true;
                    return null;
                }

                byte[] bRecData = new byte[bytes];
                for (int i = 0; i < bytes; i++)
                {
                    bRecData[i] = data[i];
                }
                if (_commDev != null)
                {
                    OnRead();
                }

                DTLastCommTime = DateTime.Now;
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
        
        private bool FindGprsHadDefineInDB(string strGprsInfo)
        {
            if (!MemCfgInfo.MemDbMgr.Get().dicMemCardWithAllInfoByClientSn.ContainsKey(strGprsInfo))
            {
                return false;
            }
            _commDev = MemCfgInfo.MemDbMgr.Get().dicMemCardWithAllInfoByClientSn[strGprsInfo];
            _commDev.CurStatus = 1;
            PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyCardStatus + _commDev.cardInfo.Id, "1");
            return true;
        }

        public bool Start()
        {
            bool bError = false;
            if (!Open())
            {
                return false;
            }

            // 
            byte[] pBufRead = null;
            string strInfo = string.Empty;// "gprs info " + strGprsInfo;
            try
            {
                //
                // 先读取GPRS配置信息
                //
                pBufRead = Read(out bError);
                if (pBufRead == null || pBufRead.Length == 0)
                {
                    pBufRead = Read(out bError);
                }
                if (pBufRead != null)
                {
                    String strGprsInfo = BitConverter.ToString(pBufRead);
                    string strEthInfo = System.Text.Encoding.ASCII.GetString(pBufRead);

                    if (pBufRead.Length < 32)
                    {
                        strInfo = strEthInfo;
                    }
                    else
                    {
                        strInfo = strGprsInfo;
                    }

                    LogMgr.WriteInfoDefSys("rec connected send info is:" + strInfo);
                    if (FindGprsHadDefineInDB(strInfo))
                    {
                        m_bGprs = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                LogMgr.WriteErrorDefSys("socket " + ex.Message);
            }

            if (!m_bGprs)
            {
                LogMgr.WriteErrorDefSys("tcp 客户端收到身份, 分析出错");
                return false;
            }

            _thread = new Thread(new ThreadStart(RunReadCyc));
            _thread.IsBackground = true;
            _bRun = true;
            _thread.Start();
            _commDev.CurStatus = 1;

            PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyCardStatus + _commDev.cardInfo.Id, "1");
            return true;

        }

        private void RunReadCyc()
        {
            DateTime dtTest = new DateTime(2000, 1, 1);
            while (_bRun)
            {
                if (dtTest.AddMinutes(5) > DateTime.Now )
                {
                    Thread.Sleep(1000);
                    continue;
                }
                string strValues = "";
                if (ReadOilValString(1, ref strValues) )
                {
                    _commDev.dtGetted = DateTime.Now;
                    _commDev.strGettedValues = strValues;
                    GlareLedSysBll.CardWithCommDevBll.UpdateOilLastValue(_commDev.cardInfo.Id, strValues);
                }
                else
                {
                }


                dtTest = DateTime.Now;
            }
        }

        public bool Write(byte[] pMsg, int iOffset, int iLen)
        {
            if (m_tcpClient == null || !m_tcpClient.Connected)
            {
                Open();
            }

            if (m_tcpClient == null || !m_tcpClient.Connected)
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
                System.Diagnostics.Debug.WriteLine("tcp write" + ex.Message);
                bSended = false;
                return bSended;
            }
            return bSended;
        }

        public void OnRead()
        {
        }

        //
        // port
        //
        TcpClient m_tcpClient;
        public MemCfgInfo.MemCardWithCommDev _commDev { get; set; }

        public TcpClient TCPCLIENT
        {
            set
            {
                m_tcpClient = value;
            }
            get
            {
                return m_tcpClient;
            }
        }

        //
        // 端口启动的采集与控制线程
        //
        private const string c_strAllFailed = "所有都失败";
        private const string c_strOnLine = "在线";
        private const string c_HandleHeat = "处理检测心跳完成";
        private const string c_Hanlder = "后台程序";


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

                LogMgr.WriteErrorDefSys("Rec cannot used data id:" +(int)_commDev.cardInfo.Id);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Assert(false);
            }
            finally
            {
            }
        }

        public bool SendOilContext(int iAddr, IList<string> lstStrings)
        {
            lock (this)
            {
                try
                {
                    ClearOldReadBuf();
                    bool bError = false;
                    IList<GlareLedSysDefPub.CardGasValEachNumAByte> lstOilVals = GLLedProtocol.MakeOilValBytesByString(lstStrings);
                    byte[] bBuf = GLLedProtocol.MakeCmdLedSetOilVal(iAddr, lstOilVals);
                    Write(bBuf, 0, bBuf.Length);
                    LogMgr.WriteInfoDefSys("send bytes:" + BitConverter.ToString(bBuf));
                    Thread.Sleep(100);
                    byte[] bRead = Read(out bError);
                    if (bRead != null)
                    {
                        LogMgr.WriteInfoDefSys("recbuf bytes:" + BitConverter.ToString(bRead));
                    }
                    return GLLedProtocol.AnalyeseRecSetOilVal(bRead, iAddr);
                }
                catch (System.Exception ex)
                {
                    LogMgr.WriteInfoDefSys("Write Execption" + ex.Message);
                    return false;
                }
            }
        }

        public bool ReadOilVal(int iAddr, ref List<GlareLedSysDefPub.CardGasValEachNumAByte> lstOilVal)
        {
            try
            {
                ClearOldReadBuf();
                bool bError = false;
                byte[] bBuf = GLLedProtocol.MakeCmdLedGetOilVal(iAddr);
                Write(bBuf, 0, bBuf.Length);
                Thread.Sleep(1000);
                byte[] bRead = Read(out bError);
                if (bRead!=null)
                {
                    LogMgr.WriteInfoDefSys("recbuf bytes:" + BitConverter.ToString(bRead));
                }
                return GLLedProtocol.AnalyeseRecGetOilVal(bRead, iAddr, ref lstOilVal);
            }
            catch (System.Exception ex)
            {
                LogMgr.WriteInfoDefSys("Write Exception" + ex.Message);
                return false;
            }
        }

        public bool ReadOilValString(int iAddr, ref string strVals)
        {
            lock(this)
            {
                try
                {
                    byte[] bBuf = GLLedProtocol.MakeCmdLedGetOilVal(iAddr);
                    Write(bBuf, 0, bBuf.Length);
                    Thread.Sleep(100);
                    bool bError = false;
                    byte[] bRead = Read(out bError);
                    if (bRead != null)
                    {
                        LogMgr.WriteInfoDefSys("recbuf bytes:" + BitConverter.ToString(bRead));
                    }
                    return GLLedProtocol.AnalyeseRecGetOilValString(bRead, iAddr, ref strVals);
                }
                catch (System.Exception ex)
                {
                    LogMgr.WriteInfoDefSys("读写异常" + ex.Message);
                    return false;
                }
            }
            
        }

        public bool SendOilDot(int iAddr, string lstStrings)
        {
            lock (this)
            {
                try
                {
                    ClearOldReadBuf();
                    int[] iArr = new int[12];
                    string[] strArr = lstStrings.Split(new char[] { '-' });
                    int i = 0;
                    foreach (string strAstr in strArr)
                    {
                        int.TryParse(strArr[i], out iArr[i]);
                        i++;
                    }
                    byte[] bBuf = GLLedProtocol.MakeCmdLedSetDecimal(iAddr, iArr);
                    Write(bBuf, 0, bBuf.Length);
                    Thread.Sleep(100);
                    bool bError = false;
                    byte[] bRead = Read(out bError);
                    if (bRead != null)
                    {
                        LogMgr.WriteInfoDefSys("recbuf bytes:" + BitConverter.ToString(bRead));
                    }
                    return GLLedProtocol.AnalyeseRecSetDecemil(bRead, iAddr);
                }
                catch (System.Exception ex)
                {
                    LogMgr.WriteInfoDefSys("读写异常" + ex.Message);
                    return false;
                }
            }
        }


        public bool TestConnected()
        {
            return _commDev.dtGetted.AddMinutes(18) > DateTime.Now;
        }

        public bool GetLedCfg(int iAddr, ref CardCfgByJson cfg)
        {
            lock (this)
            {
                try
                {
                    bool bError = false;
                    ClearOldReadBuf();
                    GlareLedSysDefPub.GasCardCfg cardcfg = new GlareLedSysDefPub.GasCardCfg();
                    byte[] bBuf = GLLedProtocol.MakeCmdLedGetCfg(iAddr);
                    Write(bBuf, 0, bBuf.Length);
                    LogMgr.WriteInfoDefSys("send to dev:" + BitConverter.ToString(bBuf));
                    Thread.Sleep(100);
                    byte[] bRead = Read(out bError);
                    bool bRet = GLLedProtocol.AnalyeseRecGetCfg(bRead, iAddr, ref cardcfg);
                    if (bRet)
                    {
                        cfg.bDobule = cardcfg.bDobule;
                        cfg.bShowAppend = cardcfg.bShowAppend;
                        cfg.iCardDigCount = cardcfg.iCardDigCount;
                        cfg.iCardType = cardcfg.iCardType;
                        cfg.iFirmVer = cardcfg.iFirmVer;
                        cfg.iHardVer = cardcfg.iHardVer;
                        cfg.iID = cardcfg.iID;
                        cfg.iLight = cardcfg.iLight;
                        cfg.iScreenCount = cardcfg.iScreenCount;
                        return true;
                    }
                    return false;
                }
                catch (System.Exception ex)
                {
                    LogMgr.WriteInfoDefSys("读写异常" + ex.Message);
                    return false;
                }
            }
        }

        public bool SetLedCfg(int iAddr, CardCfgByJson cfg)
        {
            lock (this)
            {
                try
                {
                    ClearOldReadBuf();
                    bool bError = false;
                    GlareLedSysDefPub.GasCardCfg cardcfg = new GlareLedSysDefPub.GasCardCfg();
                    cardcfg.bDobule = cfg.bDobule;
                    cardcfg.bShowAppend = cfg.bShowAppend;
                    cardcfg.iCardDigCount = cfg.iCardDigCount;
                    cardcfg.iCardType = cfg.iCardType;
                    cardcfg.iFirmVer = cfg.iFirmVer;
                    cardcfg.iHardVer = cfg.iHardVer;
                    cardcfg.iID = cfg.iID;
                    cardcfg.iLight = cfg.iLight;
                    cardcfg.iScreenCount = cfg.iScreenCount;

                    byte[] bBuf = GLLedProtocol.MakeCmdLedSetCfg(iAddr, cardcfg);
                    Write(bBuf, 0, bBuf.Length);
                    Thread.Sleep(100);
                    byte[] bRead = Read(out bError);
                    return GLLedProtocol.AnalyeseRecSetCardCfg(bRead, iAddr);
                }
                catch (System.Exception ex)
                {
                    LogMgr.WriteInfoDefSys("读写异常" + ex.Message);
                    return false;
                }
            }
        }

        public bool ReadLedDotValString(int iAddr, ref string strVals)
        {
            try
            {
                ClearOldReadBuf();
                bool bError = false;
                byte[] bBuf = GLLedProtocol.MakeCmdLedGetDecimal(iAddr);
                Write(bBuf, 0, bBuf.Length);
                Thread.Sleep(100);
                byte[] bRead = Read(out bError);
                return GLLedProtocol.AnalyeseRecGetDecmailString(bRead, ref strVals);
            }
            catch (System.Exception ex)
            {
                LogMgr.WriteInfoDefSys("读写异常" + ex.Message);
                return false;
            }
        }
    }
}
