using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using NetLabelBll;

namespace IOServer.BLL
{
    /// <summary>
    /// IO服务器的命令队列
    /// </summary>
    public class IOServerCmdQueue
    {
        object objLockOjb = new object();
        private static IOServerCmdQueue m_pInst = new IOServerCmdQueue();
        private List<RealControlModel> lstCmdQueue = new List<RealControlModel>();
        public static IOServerCmdQueue Get()
        {
            return m_pInst;
        }

        public void AddACmdItem(RealControlModel aItem)
        {
            lock (objLockOjb)
            {
                for (int i = 0; i < lstCmdQueue.Count; i++)
                {
                    if (lstCmdQueue[i].ID == aItem.ID)
                    {
                        return;
                    }
                }

                Program.AddDevMsg(MsgDirect.E_NONE, "添加命令到命令队列", "");
                lstCmdQueue.Add(aItem);
            }
        }

        public void AddItems(List<RealControlModel> lstItems)
        {
            lock (objLockOjb)
            {
                for (int i = 0; i < lstItems.Count; i++)
                {
                    AddACmdItem(lstItems[i]);
                }
            }
        }

        public void ClearOneHourBeforeCmds()
        {
            List<RealControlModel> lstWillDel = new List<RealControlModel>();
            lock (objLockOjb)
            {
                for (int i = 0; i < lstCmdQueue.Count; i++)
                {                    
                    if (lstCmdQueue[i].LogDt.AddMinutes(10) < DateTime.Now)
                    {
                        lstWillDel.Add(lstCmdQueue[i]);
                    }
                }

                foreach (RealControlModel delobj in lstWillDel)
                {
                    lstCmdQueue.Remove(delobj);
                }
            }
        }

        /// <summary>
        /// 获取属于同一个网关的命令
        /// </summary>
        /// <param name="iGatewayId"></param>
        /// <param name="lstCmdDev"></param>
        public void GetCmdByGwayId(int iGatewayId, ref List<RealControlModel> lstCmdForGateway)
        {            
            lock (objLockOjb)
            {
                for (int i = 0; i < lstCmdQueue.Count; i++)
                {
                    if (lstCmdQueue[i].GatewayId == iGatewayId)
                    {
                        lstCmdForGateway.Add(lstCmdQueue[i]);                        
                    }
                }

                foreach (RealControlModel delInIoServer in lstCmdForGateway)
                {
                    lstCmdQueue.Remove(delInIoServer);
                }
            }
        }


        public void GetCmdByProjectId(int iProjectId, ref List<RealControlModel> lstCmdDev)
        {
            List<GatewayModel> lstGates = GatewayBll.GetGatewayListByProjectId(iProjectId);
            lock (objLockOjb)
            {
                for (int i = 0; i < lstGates.Count(); i++)
                {
                    List<RealControlModel> lstAGateCmd = new List<RealControlModel>();
                    GetCmdByGwayId(lstGates[i].ID, ref lstAGateCmd);
                    lstCmdDev.AddRange(lstAGateCmd);
                }
            }            
        }

        public void Clear()
        {
            lock (objLockOjb)
            {
                lstCmdQueue.Clear();
            }
        }


    }
}
