using GlareLedSysBll;
using GlareSysDataCenter.CommRW;
using GlareSysEfDbAndModels;
using GLLedPublic;
using PiPublic;
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
            _run = true;
            Thread t = new Thread(new ThreadStart(Run));
            t.Start();
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
            while(_run)
            {
                Thread.Sleep(100);


                RemoveHendResultInMemcached();

                string strIds = PiPublic.MemcachedMgr.GetVal("NewCmdIds");
                if (strIds.Length == 0)
                {
                    continue;
                }

                List<CmdLogs> lstCmd = CmdLogsBll.GetNewCmdsByMinutes(1);
                if (lstCmd.Count ==0)
                {
                    continue;
                }

                bool bResult = false;
                string strResult = "";
                foreach (var item in lstCmd)
                {
                    if (item.CreateTime.Value.AddMinutes(1) < DateTime.Now)
                    {
                        RemoveNewCmdInMemcached(item.Id);
                    }

                    if (item.CmdType== GlareLedSysDefPub.CmdDefSetOilValue)
                    {
                        bResult = SetOilValue(item.CommDevId.Value, item.CmdInfo);
                        CmdLogsBll.UpdateACmdResult(item.Id, bResult ? 1 : 0, bResult ? "Success" : "Failed");
                        InsertNewHanedMemcached(item.Id);
                    }

                    else if(item.CmdType== GlareLedSysDefPub.CmdDefSetOilCfg)
                    {
                        bResult = SetOilCfg(item.CommDevId.Value, strResult);
                        CmdLogsBll.UpdateACmdResult(item.Id, bResult ? 1 : 0, bResult ? "Success" : "Failed");
                        InsertNewHanedMemcached(item.Id);
                    }
                    else if(item.CmdType == GlareLedSysDefPub.CmdDefGetOilValue)
                    {
                        bResult = GetOilValue(item.CommDevId.Value, out strResult);
                        CmdLogsBll.UpdateACmdResult(item.Id, bResult ? 1 : 0, bResult ? "Success" : "Failed");
                        InsertNewHanedMemcached(item.Id);
                    }
                    else
                    {

                    }

                    CmdLogsBll.UpdateACmdResult(item.Id, bResult ? 1 : 2, strResult);
                    InsertNewHanedMemcached(item.Id);
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
            TCPLisenterPort port = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient(commID);

            if (port == null)
            { return false; }

            string[] values = strValues.Split(new char[] { '-', ',' });
            List<string> lstVals = new List<string>(values);
            return port.SendOilContext(1, lstVals);
        }

        public bool GetOilValue(int commID, out string strValues)
        {
            strValues = "";
            TCPLisenterPort port = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient(commID);
            if (port == null)
            { return false; }
            List<GlareLedSysDefPub.CardGasValEachNumAByte> lstVals = new List<GlareLedSysDefPub.CardGasValEachNumAByte>();
            string strValuesTmp = "";
            bool bRt = port.ReadOilValString(1, ref strValuesTmp);
            strValues = strValuesTmp;
            return bRt;
        }

        public bool SetOilCfg(int commId, string strCfgJson)
        {
            CardCfgByJson cfg = JsonStrObjConver.JsonStr2Obj(strCfgJson,typeof(CardCfgByJson)) as CardCfgByJson;
            if (cfg == null)
            {
                return false;
            }

            TCPLisenterPort port = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient(commId);
            if (port == null)
            { return false; }
            return port.SetLedCfg(1, cfg);
        }

    }
}
