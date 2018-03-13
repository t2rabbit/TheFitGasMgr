using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Models;
using PiPublic;
using NetLabelEfDbDll.SqlServer;
using PiPublic.Log;
using IOServer.BLL.Protocol.CellsLabel;
using NetLabelEfDbDll;
using IOServer.BLL.RealControls;

namespace IOServer.BLL
{
    class IPort
    {
        private readonly Object m_lockObj = new Object();
        //public Dictionary<int, int> m_modlaststat = new Dictionary<int, int>();
        private List<RealControlModel> m_lstCmd = new List<RealControlModel>();
        protected GatewayModel gwPort;
        private Thread m_pThread;
        protected bool m_bRun;

        public void SetGwayInfo(GatewayModel obj)
        {
            gwPort = obj;
        }

        public GatewayModel GwayInfo { get { return gwPort; } }

        public string GetDevName()
        {
            if (gwPort == null)
            {
                return "";
            }
            return gwPort.Name;
        }
        
        public virtual bool _Open() { return false; }
        public virtual bool _IsOpen() { return false; }
        public virtual bool _Close() { return false; }
        public virtual void _ClearBuf() { return; }

        public virtual byte[] _Read(int iTimeout) { return null; }
        public virtual bool _Write(byte[] pMsg, int iOffset, int iLen) { return false; }
        public virtual void _OnRead() { return; }

        /// <summary>
        /// 同步时间,广播
        /// </summary>
        /// <returns></returns>
        public virtual bool _SyncAllTimeByBroad() 
        {
            lock (m_lockObj)
            {
                ushort devAddr = 0xffff;
                byte[] bArr = CLN_1601_Protocol.MakeSendSetTimeCmd(devAddr, 0, 0, DateTime.Now);
                if (bArr == null)
                {
                    return false;
                }

                _Write(bArr, 0, bArr.Length);
                Thread.Sleep(100);
                LogMgr.WriteInfoDefSys("发送广播对时命令:");
                LogMgr.WriteInfoDefSys(BitConverter.ToString(bArr));
            }
            
            return true;
        }

        public virtual bool _SyncTimeByDev(DevInfoModel aModule)
        {
            lock (m_lockObj)
            {
                int iAddr = Convert.ToInt16(aModule.DevAddr, 16);
                byte[] bArr = CLN_1601_Protocol.MakeSendSetTimeCmd((ushort)0, iAddr, 0, DateTime.Now);
                if (bArr == null)
                {
                    return false;
                }

                _Write(bArr, 0, bArr.Length);
                Thread.Sleep(100);
                byte[] bRead = _Read(0);
                LogMgr.WriteInfoDefSys("发送对时命令:");
                LogMgr.WriteInfoDefSys(BitConverter.ToString(bArr));
                LogMgr.WriteInfoDefSys("接收:");
                LogMgr.WriteInfoDefSys(BitConverter.ToString(bRead));
            }
            
            return true;
        }

        public virtual void _HandleCmd()
        {
            m_lstCmd.Clear();
            IOServerCmdQueue.Get().GetCmdByGwayId(gwPort.ID, ref m_lstCmd);
            if (m_lstCmd.Count == 0)
            {
                return;
            }

            List<RealControlModel> lstCmdDo = new List<RealControlModel>();
            lstCmdDo.AddRange(m_lstCmd);
            m_lstCmd.Clear();

            foreach (RealControlModel aCmd in lstCmdDo)
            {
                LogMgr.WriteInfoDefSys("端口获取到命令需要处理,命令条数为 :" + lstCmdDo.Count);                
                try
                {
                    LogMgr.WriteInfoDefSys("hand cmd id:", aCmd.ID.ToString());
                    
                    string strModType = "";
                    
                    IModuleCmdHander aCmdHandler = ModuleCmdHandlerFactor.Get().GetNodeGetterByType(strModType);

                    if (aCmdHandler == null)
                    {
                        System.Diagnostics.Trace.WriteLine("hand cmd id: " + aCmd.ID + " ModuleCmdHander is null");
                        continue;
                    }

                    string strCmdHandedMsg = "";
                    string strTmp = string.Format("id in db:{0}, cmdstring:{1}", aCmd.ID, aCmd.Cmd);
                    LogMgr.WriteInfoDefSys(strTmp, "");                    

                    bool bHandled = aCmdHandler._HandleCmd(this, aCmd, ref strCmdHandedMsg);                    
                    DBMgr.Get().UpdateHandledCmd(aCmd.ID, DbConstDefine.CmdFlag.CmdHandedSuccess);//
                    //DBMgr.Get().InsertHandleCmd(aCmd.ID, iCmdStatus, strCmdHandedMsg, "port:" + m_aDev.ID + ",name:" + m_aDev.Name);
                }
                catch (System.Exception ex)
                {
                    LogMgr.WriteErrorDefSys(ex.Message);
                }

            }

            return;
        }

        //
        // 函数模板
        //      
  
        /// <summary>
        /// 获取所有设备的节点数据
        /// </summary>
        /// <returns></returns>
        public virtual bool _GetAllNodeByGw() 
        {
            bool bHadSuccess = false;
            IList<DevInfoModel> lstModuleOfGw = (from c in DBMgr.Get().ListDev 
                                                 where c.GatewayId == gwPort.ID 
                                                 select c).ToList();

            List<NodeInfoModel> lstNode = DBMgr.Get().ListNode.ToList();
            foreach (DevInfoModel aMod in lstModuleOfGw)
            {
                if (!m_bRun)
                {
                    break;
                }
//                 if (aMod.BEnable != 1)
//                 {
//                     continue;
//                 }

                int iRet = _GetAllNodeByModule(aMod, lstNode);

                LastStatusMgr.Get().UpdateDevStatusToMem(aMod.ID,
                    iRet == 0 ? LastStatusInfo.EStatus.ESOffLine : LastStatusInfo.EStatus.ESOnLine);

                if (iRet != 0)
                {
                    bHadSuccess = true;
                }
            }

            return bHadSuccess;
        }


        public void UpdateNodeLastVal(List<NodeInfoModel> lst, int iDveId, string strCataLog1, int iVal)
        {
            NodeInfoModel aNode = (from c in lst
                                   where c.DevId == iDveId && c.strCatalog1 == strCataLog1
                                   select c
                                   ).FirstOrDefault();
            if (aNode == null)
            {
                return;
            }

            MemNodeValueMgr.Get().UpdateNewstValueInMem(aNode.ID, iVal, DateTime.Now, (int)DbConstDefine.ValueFlag.ValueOk);
        }


        // 返回1表示全部获取成功，0表示一个都没有获取成功，2表示部分获取成功
        public virtual int _GetAllNodeByModule(DevInfoModel aModule, List<NodeInfoModel> lstNods)
        {
            if (!m_bRun)
            {
                return 0;
            }
            bool bSuccess = false;

            lock (m_lockObj)
            {
                int iAddr = Convert.ToInt16(aModule.DevAddr, 16);
                int[] ivalout = new int[8];
                _HandleCmd();

                byte[] bCmd = CLN_1601_Protocol.MakeCtlGetVal((ushort)iAddr, aModule.DevLineIndex);
                _Write(bCmd, 0, bCmd.Length);
                Thread.Sleep(100);
                byte[] pRecBuf = _Read(0);
                if (pRecBuf == null)
                {
                    return 0;
                }

                if (CLN_1601_Protocol.AnalyseReadValRet(pRecBuf, pRecBuf.Length,
                    (ushort)iAddr, aModule.DevLineIndex,ref ivalout) )
                {
                    UpdateNodeLastVal(lstNods, aModule.ID, NodeTypeCatalogDefine.AddrTemperature.ToString(), ivalout[0]);
                    UpdateNodeLastVal(lstNods, aModule.ID, NodeTypeCatalogDefine.AddrHumidity.ToString(), ivalout[1]);
                    UpdateNodeLastVal(lstNods, aModule.ID, NodeTypeCatalogDefine.AddrVoltage.ToString(), ivalout[2]);
                    UpdateNodeLastVal(lstNods, aModule.ID, NodeTypeCatalogDefine.AddrCurrent.ToString(), ivalout[3]);
                }
                bSuccess = true;                
            }

            return bSuccess ? 1 : 0;
        }


        public void Start()
        {
            Stop();

            m_pThread = new Thread(new ThreadStart(Run));
            m_pThread.IsBackground = true;
            m_bRun = true;
            m_pThread.Start();
        }

        public void Stop()
        {
            try
            {
                if (m_pThread != null)
                {
                    _Close();
                    m_bRun = false;
                    m_pThread.Join(10000);
                    if (m_pThread.IsAlive)
                    {
                        m_pThread.Abort();
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
            finally
            {
                m_pThread = null;
            }
        }

        private readonly string strOffLine = "掉线";
        private readonly string strOnLine = "在线";

        private void Run()
        {
            int iPickRate = 0;
            ConfigHlper.GetConfig_Int(ConstDef.KEY_CFG_PICKUPRATE, 60, out iPickRate);
            if (iPickRate < 1)
            {
                iPickRate = 60;
            }

            DateTime dtLastSyncTime = DateTime.Now.AddDays(-100);

            bool bRet = false;
            int iDevLastStau = 1;
            while (m_bRun)
            {
                try
                {
                    DateTime dtNow = DateTime.Now;
                    if (!_IsOpen())
                    {
                        _Open();
                    }

                    if (!_IsOpen())
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    LastStatusMgr.Get().UpdateGwStatusToMem(this.GwayInfo.ID, LastStatusInfo.EStatus.ESOnLine);
                    
                    if (!m_bRun)
                    {
                        break;
                    }

                    _HandleCmd();
                    LogMgr.WriteInfoDefSys("获取所有设备的状态，传感器");
                    bRet = _GetAllNodeByGw();
                    _HandleCmd();

                    Thread.Sleep(1000);
                    if (dtLastSyncTime.AddDays(1) < DateTime.Now)
                    {
                        if (_SyncAllTimeByBroad())
                        {
                            dtLastSyncTime = DateTime.Now;
                        }
                    }

                    if (bRet)
                    {
                       
                    }
                    else
                    {
                    }
                    DelayForSecs(dtNow, iPickRate);
                }
                catch (System.Exception ex)
                {
                    string strLog = string.Format("**-** exc iport run:{0}", ex.Message);
                    LogMgr.WriteErrorDefSys(strLog);
                    LogMgr.WriteErrorDefSys(ex.StackTrace.ToString());
                    continue;
                }                
            }
            this._Close();
        }


        private void UpdateAllDevAsOffLine()
        {
        }


        /// <summary>
        /// 采集大循环时间，休眠
        /// </summary>
        /// <param name="dtLastRun"></param>
        /// <param name="iSesc"></param>
        private void DelayForSecs(DateTime dtLastRun, int iSesc)
        {
            // 在计划的时间内采集一次
            TimeSpan ts = (DateTime.Now - dtLastRun);
            if (ts.TotalSeconds < iSesc)
            {
                while (ts.TotalSeconds < iSesc)
                {
                    ts = (DateTime.Now - dtLastRun);
                    _HandleCmd();
                    Thread.Sleep(1000);
                    if (!m_bRun)
                        break;
                }
            }
        }

    }

}
