using GlareLedSysBll;
using GlareSysDataCenter.CommRW;
using GlareSysEfDbAndModels;
using GLLedPublic;
using PiPublic;
using PiPublic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GlareSysDataCenter
{
    class CmdOp
    {
        Thread _thread;
        bool _run;
        private Dictionary<int, DateTime> dicWillDelHandedMemcached = new Dictionary<int, DateTime>();

        private static CmdOp _inst;
        protected CmdOp() { }
        public static CmdOp Get()
        {
            if (_inst == null)
            { _inst = new CmdOp(); }
            return _inst;
        }

        public void Start()
        {
            Stop();
            _run = true;
            _thread = new Thread(new ThreadStart(Run));
            _thread.IsBackground = true;
            _thread.Start();
        }
        public void Stop()
        {
            if (_thread!=null)
            {
                _run = false;
                if(!_thread.Join(1000) )
                {
                    _thread.Abort();
                }
                _thread = null;
            }
        }

        private bool RemoveNewCmdInMemcached(int id)
        {
            bool bFind = false;

            string strIds = PiPublic.MemcachedMgr.GetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd);
            if (strIds.Length == 0)
            {
                return false;
            }


            string[] arrIds = strIds.Split(new char[] { '-', ',' });
            string strNewIds = "";
            foreach (var str in arrIds)
            {
                if (str == id.ToString())
                {
                    bFind = true;
                    continue;
                }

                if (strNewIds.Length > 0)
                {
                    strNewIds += ",";
                    strNewIds += str;
                }
            }
            PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, strNewIds);
            return bFind;
        }

        private void RemoveHendResultInMemcached()
        {
            foreach (var item in dicWillDelHandedMemcached)
            {
                if (DateTime.Now > item.Value.AddMinutes(1))
                {
                    string strIds = PiPublic.MemcachedMgr.GetVal("ResultIds");
                    if (strIds.Length == 0)
                    {
                        return;
                    }

                    if (strIds==item.Key.ToString())
                    {
                        PiPublic.MemcachedMgr.SetVal("ResultIds", "");
                    }

                    string[] arrIds = strIds.Split(new char[] { '-', ',' });
                    string strNewIds = "";
                    foreach (var str in arrIds)
                    {
                        if (str ==item.Key.ToString())
                        {
                            continue;
                        }

                        if (strNewIds.Length>0)
                        {
                            strNewIds += ",";
                            strNewIds += str;
                        }
                    }
                    PiPublic.MemcachedMgr.SetVal("ResultIds", strNewIds);
                }
            }
        }

        public void Run()
        {
            int iTestNoCmdTickCount = 0;
            while(_run)
            {
                try
                {
                    Thread.Sleep(100);
                    RemoveHendResultInMemcached();

                    string strIds = PiPublic.MemcachedMgr.GetVal("NewCmdIds");

                    PiPublic.MemcachedMgr.SetVal("NewCmdIds", "");
                    if (strIds.Length == 0)
                    {
                        iTestNoCmdTickCount++;
                        if (iTestNoCmdTickCount > 1000)
                        {
                            iTestNoCmdTickCount = 0;
                            PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyCmdResult, "");
                        }
                        continue;
                    }


                    PiPublic.Log.LogMgr.WriteDebugDefSys("memcached cmd id is" + strIds);

                    iTestNoCmdTickCount = 0;
                    List<CmdLogs> lstCmd = CmdLogsBll.GetNewCmdsByMinutes(3);
                    if (lstCmd.Count == 0)
                    {
                        // 时间过期到命令
                        PiPublic.Log.LogMgr.WriteDebugDefSys("memcached cmd timeouted....");
                        PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, "");
                        continue;
                    }

                    bool bResult = false;
                    string strResult = "";
                    foreach (var item in lstCmd)
                    {
                        LogMgr.WriteDebugDefSys("handleing cmd id is" + item.Id + "create dt is" + item.CreateTime);
                        if (item.CreateTime.Value.AddMinutes(1) < DateTime.Now)
                        {
                            RemoveNewCmdInMemcached(item.Id);
                            CmdLogsBll.UpdateACmdResult(item.Id, 99, "timeoutcmd");
                            continue;
                        }

                        if (item.CmdType == GlareLedSysDefPub.CmdDefSetOilValue)
                        {
                            bResult = SetOilValue(item.CommDevId.Value, item.CmdInfo);
                            CmdLogsBll.UpdateACmdResult(item.Id, bResult ? 1 : 99, bResult ? "Success" : "Failed");
                            InsertNewHanedMemcached(item.Id);
                        }
                        else if (item.CmdType == GlareLedSysDefPub.CmdDefSetOilCfg)
                        {
                            bResult = SetOilCfg(item.CommDevId.Value, item.CmdInfo);
                            CmdLogsBll.UpdateACmdResult(item.Id, bResult ? 1 : 99, bResult ? "Success" : "Failed");
                            InsertNewHanedMemcached(item.Id);
                        }
                        else if (item.CmdType == GlareLedSysDefPub.CmdDefGetOilCfg)
                        {
                            bResult = GetOilCfgBySpilits(item.CommDevId.Value, out strResult);
                            CmdLogsBll.UpdateACmdResult(item.Id, bResult ? 1 : 99, strResult);
                            InsertNewHanedMemcached(item.Id);
                        }
                        else if (item.CmdType == GlareLedSysDefPub.CmdDefGetOilValue)
                        {
                            bResult = GetOilValue(item.CommDevId.Value, out strResult);
                            CmdLogsBll.UpdateACmdResult(item.Id, bResult ? 1 : 99, strResult);
                            InsertNewHanedMemcached(item.Id);
                        }
                        else if (item.CmdType == GlareLedSysDefPub.CmdDefSetOilDigiCfg)
                        {
                            bResult = SetOilDigi(item.CommDevId.Value, item.CmdInfo);
                            CmdLogsBll.UpdateACmdResult(item.Id, bResult ? 1 : 99, bResult ? "Success" : "Failed");
                            InsertNewHanedMemcached(item.Id);
                        }
                        else if (item.CmdType == GlareLedSysDefPub.CmdDefGetOilDigiCfg)
                        {
                            bResult = GetOilDigiCfgBySpilits(item.CommDevId.Value, out strResult);
                            CmdLogsBll.UpdateACmdResult(item.Id, bResult ? 1 : 99, strResult);
                            InsertNewHanedMemcached(item.Id);
                        }
                        else
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMgr.WriteErrorDefSys("cmd op thread ex:");
                    LogMgr.WriteErrorDefSys(ex.Message);
                }


            }
        }

        private void InsertNewHanedMemcached(int id)
        {

            string strIds = PiPublic.MemcachedMgr.GetVal(GlareLedSysDefPub.MemcachedKeyCmdResult);
            if (strIds.Length != 0)
            {
                strIds += "," + id.ToString();
            }
            else
            { strIds = id.ToString(); }

            PiPublic.MemcachedMgr.SetVal(GlareLedSysDefPub.MemcachedKeyCmdResult, strIds);

            if (!dicWillDelHandedMemcached.ContainsKey(id))
            {
                dicWillDelHandedMemcached.Add(id, DateTime.Now);
            }
        }

        public bool SetOilValue(int commID, string strValues)
        {
            TCPLisentedPort port = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient(commID);

            if (port == null)
            {
                LogMgr.WriteDebugDefSys("commdev dnot connect...");
                return false;
            }

            string[] values = strValues.Split(new char[] { '-', ',' });
            List<string> lstVals = new List<string>(values);
            return port.SendOilContext(1, lstVals);
        }


        public bool SetOilDigi(int commID, string strValues)
        {
            TCPLisentedPort port = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient(commID);

            if (port == null)
            { return false; }

            string[] values = strValues.Split(new char[] { '-', ',' });
            List<string> lstVals = new List<string>(values);
            return port.SendOilDot(1, strValues);
        }


        public bool GetOilValue(int commID, out string strValues)
        {
            strValues = "";
            TCPLisentedPort port = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient(commID);
            if (port == null)
            { return false; }
            List<GlareLedSysDefPub.CardGasValEachNumAByte> lstVals = new List<GlareLedSysDefPub.CardGasValEachNumAByte>();
            string strValuesTmp = "";
            bool bRt = port.ReadOilValString(1, ref strValuesTmp);
            strValues = strValuesTmp;
            return bRt;
        }
        
        public bool GetOilCfgBySpilits(int commID, out string strValues)
        {
            strValues = "";
            TCPLisentedPort port = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient(commID);
            if (port == null)
            { return false; }
            List<GlareLedSysDefPub.CardGasValEachNumAByte> lstVals = new List<GlareLedSysDefPub.CardGasValEachNumAByte>();            
            CardCfgByJson cfg = new CardCfgByJson();
            bool bRt = port.GetLedCfg(1,  ref cfg);
            string strOut = (cfg.bDobule ? "1" : "0");
            strOut += "-" + cfg.iScreenCount.ToString();
            strOut += "-" + cfg.iCardDigCount;
            strOut += "-";
            strOut += cfg.bShowAppend ? "1" : "0";
            strOut +="-" + cfg.iLight;

            strValues = strOut;
            return bRt;
        }


        public bool GetOilDigiCfgBySpilits(int commID, out string strValues)
        {
            strValues = "";
            TCPLisentedPort port = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient(commID);
            if (port == null)
            { return false; }
            List<GlareLedSysDefPub.CardGasValEachNumAByte> lstVals = new List<GlareLedSysDefPub.CardGasValEachNumAByte>();
            string strOut="";
            bool bRt = port.ReadLedDotValString(1, ref strOut);
            
            strValues = strOut;
            return bRt;
        }

        public bool SetOilCfg(int commId, string strStringBySpilt)
        {
            LogMgr.WriteDebugDefSys("handleing cmd SetOilCfg");
            string[] strArr = strStringBySpilt.Split(new char[] {',','-' });
            if (strArr.Length != 5 )
            { return false; }
            int[] iArr = new int[5];
            for (int i = 0; i < 5; i++)
            {
                iArr[i] = int.Parse(strArr[i]);
            }


            CardCfgByJson cfg = new CardCfgByJson()
            {
                iCardType = 0,
                iFirmVer = 0,
                iHardVer = 0,
                iID = 0,
                bDobule = iArr[0] == 1,
                iScreenCount = iArr[1],
                iCardDigCount = iArr[2],
                bShowAppend = iArr[3] == 1,
                iLight = 8,
            };

            TCPLisentedPort port = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient(commId);
            if (port == null)
            {
                LogMgr.WriteDebugDefSys("handing cmd SetOilCfg dev is not connected...");
                return false;
            }

            return port.SetLedCfg(1, cfg);
        }

    }
}
