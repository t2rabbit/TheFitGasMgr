using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Concurrent;
using System.IO;
using NetLabelEfDbDll.SqlServer;
using NetLabelEfDbDll;
using Models;
using NetLabelBll;

namespace IOServer.BLL
{
	public class DBMgr
	{
        public ConcurrentBag<GatewayModel> LstPortGaweway 
        { 
            get;
            private set;
        }

        public ConcurrentBag<DevInfoModel> ListDev 
        { 
            get;
            private set;
        }

        public ConcurrentBag<NodeInfoModel> ListNode
        {
            get;
            private set;
        }

        private void ClearOjbs()
        {
            GatewayModel aPortTake;
            while (LstPortGaweway.TryTake(out aPortTake))
            {

            }

            DevInfoModel aModTake;
            while (ListDev.TryTake(out aModTake))
            {

            }

            NodeInfoModel aNodeTake;
            while (ListNode.TryTake(out aNodeTake))
            {

            }
        }

		public void ReloadDBToList()
		{
            ClearOjbs();

            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {            
                
				List<GatewayModel> lstPortTmp = GatewayBll.GetAllGatewayList();
                List<DevInfoModel> lstModule = DevBll.GetAllDev();
                List<NodeInfoModel> lstNode = NodeBll.GetAllNode();
                


                foreach (GatewayModel aItem in lstPortTmp)
                {
                    LstPortGaweway.Add(aItem);
                }
                
                foreach (DevInfoModel aItem in lstModule)
                {
                    ListDev.Add(aItem);
                }
                foreach (NodeInfoModel aItem in lstNode)
                {
                    ListNode.Add(aItem);
                }
			}
		}


		public int GetHadRealTimeItemCount()
		{
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
			{
				return ent.RealtimeValueTable.Count();
			}
		}

        public void UpdateHandledCmd(int iDBID, DbConstDefine.CmdFlag eFlag)
        {
            int iSataus = (int)eFlag;
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                RealControl aCmd = ent.RealControl.FirstOrDefault(cc => cc.ID == iDBID);
                if (aCmd == null)
                {
                    return;
                }

                aCmd.CmdFlag = iSataus;                
                ent.SaveChanges();
            }
        }


		public void InsertHandleCmd(int iHandleFor, int iResult, string ResultMsg, string strHandelByUser)
		{
			System.Diagnostics.Trace.WriteLine("数据库没有添加handle by字段，，，添加后需要删除");
            RealControlLog aHandled = new RealControlLog()
            {
                ForCmdId = iHandleFor,
                HandledInfo = ResultMsg,
                HandledResult = iResult,
                HandledByUserInfo = strHandelByUser,
                
            };
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
			{
                ent.RealControlLog.AddObject(aHandled);
				ent.SaveChanges();
			}
		}


// 
// 
//         private void ReMakeCommObjsAllDev(ConcurrentBag<cnwlcs_PortDdev> lstDev)
//         {
//             using (cn_wlcsEntitiesSqlServer ent = new cn_wlcsEntitiesSqlServer())
//             {
//                 List<cnwlcs_communicationobject> lstMainCommObjs = ent.cnwlcs_communicationobject.ToList<cnwlcs_communicationobject>();
//                 foreach (cnwlcs_PortDdev aDev in lstDev)
//                 {
//                     object aObj = (from c in lstMainCommObjs
//                                    where c.DevID == aDev.ID &&
//                                     c.Cata1 == DBDefines.CommObjDef.E_CATA_1_DEVS &&
//                                     c.Cata2 == DBDefines.CommObjDef.E_CATA_2_PORT
//                                    select c).FirstOrDefault();
// 
//                     if (aObj == null)
//                     {
//                         cnwlcs_communicationobject aNewObj = new cnwlcs_communicationobject()
//                         {
//                             DevID = aDev.ID,
//                             GwID = 0,
//                             Cata1 = DBDefines.CommObjDef.E_CATA_1_DEVS,
//                             Cata2 = DBDefines.CommObjDef.E_CATA_2_PORT,
//                             Cata3 = "",
//                             ModuleID = 0,
//                             Name = aDev.Name,
//                             Timeout = DBDefines.CommObjDef.E_TIMEOUT,
//                             UpdateMsg = "正在查询...",
//                             UpdateStatus = "",
//                             UpdateTime = DateTime.Now.AddYears(-100),
//                         };
//                         ent.cnwlcs_communicationobject.AddObject(aNewObj);
//                     }
//                 }
//                 ent.SaveChanges();
//             }
//         }
// 
//         private void ReMakeCommObjsAllModule(ConcurrentBag<cnwlcs_module> lstModule)
//         {
//             using (cn_wlcsEntitiesSqlServer ent = new cn_wlcsEntitiesSqlServer())
//             {
//                 List<cnwlcs_communicationobject> lstMainCommObjs = ent.cnwlcs_communicationobject.ToList<cnwlcs_communicationobject>();
//                 foreach (cnwlcs_module aModule in lstModule)
//                 {
//                     object aObj = (from c in lstMainCommObjs
//                                    where c.ModuleID == aModule.ID
//                                    select c).FirstOrDefault();
// 
//                     if (aObj == null)
//                     {
//                         cnwlcs_communicationobject aNewObj = new cnwlcs_communicationobject()
//                         {
//                             DevID = aModule.DevID,
//                             GwID = 0,
//                             Cata1 = DBDefines.CommObjDef.E_CATA_1_DEVS,
//                             Cata2 = DBDefines.CommObjDef.E_CATA_2_MODULE,
//                             Cata3 = "",
//                             ModuleID = aModule.ID,
//                             Name = aModule.Name,
//                             Timeout = DBDefines.CommObjDef.E_TIMEOUT,
//                              iLastStatus = DBDefines.CommObjectStatus.iCommNotChecked,
//                             UpdateMsg = "正在查询...",
//                             UpdateStatus = "",
//                             UpdateTime = DateTime.Now
//                         };
//                         ent.cnwlcs_communicationobject.AddObject(aNewObj);
//                     }
//                 }
// 
//                 ent.SaveChanges();
//             }
//         }


        //// 根据数据库中的设备和模块信息构造通信检测对象的数据项
        //private void ReMakeCommObjs()
        //{
        //    ReMakeCommObjsAllDev(ListDevPort);
        //    ReMakeCommObjsAllModule(ListModule);
        //}

// 
//         public bool AddRealtimeDataToDBByDevID(int iDevId, float fValue)
//         {
//             int iNodeID = 0;
//             List<NodeInfoModel> lstNode = ListNode.ToList();
// 
//             for (int i = 0; i < lstNode.Count; i++)
//             {
//                 if (lstNode[i].DevId == iDevId )
//                 {
//                     iNodeID = lstNode[i].ID;
//                     break;
//                 }
//             }
//             if (iNodeID == 0)
//             {
//                 return false;
//             }
//           
//             cnwlcs_realtimeitem rtData = new cnwlcs_realtimeitem()
//             {
//                 AvgValue = fValue,
//                 CurValue = fValue,
//                 DataCount = 1,
//                 Increment = 0,
//                 LogDT = DateTime.Now,
//                 ID = 0,
//                 MinValue = fValue,
//                 NodeID = iNodeID,
//                 RecordType = 0,
//                 RMaxValue = 0,
//                 ValueFlag = 0,
//             };
// 
//             using (cn_wlcsEntitiesSqlServer ent = new cn_wlcsEntitiesSqlServer())
//             {
//                 ent.cnwlcs_realtimeitem.AddObject(rtData);
//                 try
//                 {
//                     ent.SaveChanges();
//                 }
//                 catch (System.Exception ex)
//                 {
//                     System.Diagnostics.Debug.WriteLine(ex.Message);
//                     return false;
//                 }
//             }
// 
//             return true;
//         }

		public bool AddRealtimeDataToDB(int iNodeID, float fValue)
		{
            RealtimeValueTable rtData = new RealtimeValueTable()
            {
                LogDt = DateTime.Now,
                NodeId = iNodeID,
                Value = fValue,
                ValueFlag = 1
            };

            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
			{
                ent.RealtimeValueTable.AddObject(rtData);
				try
				{
					ent.SaveChanges();
				}
				catch (System.Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
					return false;
				}
			}

			return true;			
		}

		//
		// 单件支持
		//
		#region 单件支持		
		private static DBMgr m_pInst;
		protected DBMgr()
		{
            // 构造函数保护
            LstPortGaweway = new ConcurrentBag<GatewayModel>();
            ListDev = new ConcurrentBag<DevInfoModel>();
            ListNode = new ConcurrentBag<NodeInfoModel>();
            
		}

		static public DBMgr Get()
		{
			if (m_pInst == null)
			{
				m_pInst = new DBMgr();
                m_pInst.ReloadDBToList();
			}
			return m_pInst;
		}
		#endregion 单件支持
	}
}
