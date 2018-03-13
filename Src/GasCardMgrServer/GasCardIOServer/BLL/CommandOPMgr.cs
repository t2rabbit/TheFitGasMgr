using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using IOServer;
using PiPublic;
using PiPublic.Log;
using Models;
using NetLabelBll;


namespace IOServer.BLL
{
    //
    // 命令处理器，启动就开启线程，定时读取命令，看是否有命令需要处理
    //
    class CommandOPMgr
    {
        CommandOPMgr() { }
        private static CommandOPMgr m_pInst;
        public static CommandOPMgr Get()
        {
            if (m_pInst == null)
            {
                m_pInst = new CommandOPMgr();
            }
            return m_pInst;
        }

        private Thread m_pThread;
        private bool m_bRun;
        private Dictionary<int, DateTime> m_dicHandled = new Dictionary<int, DateTime>();

        public void Start()
        {
            Stop();

            m_pThread = new Thread(new ThreadStart(_Run));
            m_bRun = true;
            m_pThread.Start();
        }

        public void Stop()
        {
            //Program.AddDevMsg(MsgDirect.E_NONE, "COM OP MGR 线程停止", DateTime.Now.ToString() );
            LogMgr.WriteInfoDefSys("COM OP MGR 线程停止", DateTime.Now.ToString());
            m_bRun = false;

            try
            {
                if (m_pThread != null)
                {
                    m_bRun = false;
                    m_pThread.Join(1000);
                    if (m_pThread.IsAlive)
                    {
                        m_pThread.Abort();
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            finally
            {
                m_pThread = null;
            }

        }
   
        /// <summary>
        /// 如果时间超时的命令，需要删除
        /// </summary>
        /// <param name="lstCmd"></param>
        private void SetTimeoutCmd(ref List<RealControlModel> lstCmd)
        {
            List<RealControlModel> lstDelCmds = new List<RealControlModel>();

            for (int i = 0; i < lstCmd.Count; i++)
            {
                RealControlModel aDBCmd = lstCmd[i];

                if (aDBCmd.LogDt.AddMinutes(10) < DateTime.Now)
                {
                    DBMgr.Get().UpdateHandledCmd(aDBCmd.ID,
                        NetLabelEfDbDll.DbConstDefine.CmdFlag.CmdTimeout);

                    lstDelCmds.Add(aDBCmd);
                }
            }

            foreach (RealControlModel acmd in lstDelCmds)
            {
                lstCmd.Remove(acmd);
            }
        }

        private void _Run()
        {
            int iDelay = 4;
            bool bFirst = true;
            while (m_bRun)
            {
                try
                {
                    if (bFirst)
                    {
                        bFirst = false;
                    }
                    else
                    {
                        GroupMsgBus.eventReloadDbCmd.WaitOne(3 * 1000);
                    }
                    List<RealControlModel> lstCmd = ControlBll.GetCmdNotHanded();
                    if (lstCmd.Count == 0)
                    {
                        continue;
                    }
                    
                    //SetTimeoutCmd(ref lstCmd);
                    //IgnorHandledCmd(ref lstCmd);
                    if (lstCmd.Count>0)
                    {
                        LogMgr.WriteInfoDefSys("获取到有命令需要处理,命令数量为:" + lstCmd.Count);
                        PutCmdToCmdQueue(lstCmd);
                    }

                    //ClearOneHourBeforeCmds();

                    iDelay = 4;
                    while (iDelay-- > 0 && m_bRun)
                    {
                        Thread.Sleep(1000);
                    }
                }
                catch (System.Exception ex)
                {
                    LogMgr.WriteDebugDefSys("命令处理线程 ex :" + ex.Message);
                    LogMgr.WriteDebugDefSys(ex.Source);
                    LogMgr.WriteDebugDefSys(ex.StackTrace);
                    Thread.Sleep(1000);
                }
            }
        }

        private void PutCmdToCmdQueue(List<RealControlModel> lstCmd)
        {
            IOServerCmdQueue.Get().AddItems(lstCmd);
        }

        private void ClearOneHourBeforeCmds()
        {
            IOServerCmdQueue.Get().ClearOneHourBeforeCmds();

            foreach (KeyValuePair<int, DateTime> item in m_dicHandled)
            {
                if (item.Value.AddHours(1) < DateTime.Now)
                {
                    m_dicHandled.Remove(item.Key);
                    return;
                }
            }
            
        }

        private void IgnorHandledCmd(ref List<RealControlModel> lstCmd)
        {
            List<RealControlModel> lstDelCmds = new List<RealControlModel>();
            for (int i=0; i<lstCmd.Count; i++)
            {
                if (m_dicHandled.ContainsKey(lstCmd[i].ID))
                {
                    lstDelCmds.Add(lstCmd[i]);
                    continue;
                }
                m_dicHandled.Add(lstCmd[i].ID, DateTime.Now);
            }

            foreach (RealControlModel acmd in lstDelCmds)
            {
                lstCmd.Remove(acmd);
            }
        }



        private void SetCmdHanding(List<RealControlModel> lstCmd)
        {
            List<RealControlModel> lstDelCmds = new List<RealControlModel>();
            for (int i = 0; i < lstCmd.Count; i++)
            {
                DBMgr.Get().UpdateHandledCmd(lstCmd[i].ID,
                    NetLabelEfDbDll.DbConstDefine.CmdFlag.CmdHandling);                
            }
        }

        private void CheckResultInsertToDB()
        {

        }
    }

}
