using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

#if SQL_SERVER
using NetLabelEfDbDll.SqlServer;
#endif

namespace NetLabelBll
{
    /// <summary>
    /// 网关的增删改查
    /// </summary>
    public class GatewayBll
    {

        public static List<GatewayModel> GetAllGatewayList()
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                List<GatewayModel> lstOut = new List<GatewayModel>();
                List<GatewayInfo> lsts = (from c in ent.GatewayInfo select c).ToList();
                foreach (GatewayInfo info in lsts)
                {
                    GatewayModel aMod = new GatewayModel()
                    {
                        ID = info.ID,
                        CommType = info.Communication_Type,
                        Name = info.Name,
                        ProtocolSIM = info.Protocol_SIM,
                        ProtocolSN = info.Protocol_SN,
                        ProtocolType = info.Protocol_Type,
                        ProjectId = (int)info.ProjectID,
                        Status = (int)info.Status
                    };
                    lstOut.Add(aMod);
                }
                return lstOut;
            }
        }

        public static List<GatewayModel> GetGatewayListByProjectId(int iProjectId)
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                List<GatewayModel> lstOut = new List<GatewayModel>();
                List<GatewayInfo> lsts = (from c in ent.GatewayInfo
                                          where c.ProjectID == iProjectId
                                          select c).ToList();
                foreach (GatewayInfo info in lsts)
                {
                    GatewayModel aMod = new GatewayModel()
                    {
                        ID = info.ID,
                        CommType = info.Communication_Type,
                        Name = info.Name,
                        ProtocolSIM = info.Protocol_SIM,
                        ProtocolSN = info.Protocol_SN,
                        ProtocolType = info.Protocol_Type,
                        ProjectId = (int)info.ProjectID,
                        Status = (int)info.Status
                    };
                    lstOut.Add(aMod);
                }
                return lstOut;
            }
        }

        public static List<GatewayModel> GetGatewayByCondtion(string strCond, string strOrder)
        {
            StringBuilder sb = new StringBuilder();
#if SQL_SERVER
            sb.Append("select * from gatewayinfo ");
            if (strCond.Length > 0)
            {
                sb.Append(" where ");
                sb.Append(strCond);
            }
            if (strOrder.Length > 0)
            {
                sb.Append(" order by ");
                sb.Append(strOrder);
            }
#else
            //
            // mysql 可能语句不一样
            //
#endif

            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                List<GatewayModel> lstOut = new List<GatewayModel>();
                List<GatewayInfo> lsts = ent.ExecuteStoreQuery<GatewayInfo>(sb.ToString()).ToList();
                foreach (GatewayInfo info in lsts)
                {
                    GatewayModel aMod = new GatewayModel()
                    {
                        ID = info.ID,
                        CommType = info.Communication_Type,
                        Name = info.Name,
                        ProtocolSIM = info.Protocol_SIM,
                        ProtocolSN = info.Protocol_SN,
                        ProtocolType = info.Protocol_Type,
                        ProjectId = (int)info.ProjectID,
                        Status = (int)info.Status
                    };
                    lstOut.Add(aMod);
                }
                return lstOut;
            }  
        }


        public static bool AddGatewayInfo(ref GatewayModel model, out string strError)
        {
            // todo 检查名字是否重复
            strError = "";
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    GatewayInfo newinfo = new GatewayInfo()
                    {
                        Communication_Type = model.CommType,
                        ID = model.ID,
                        Name = model.Name,
                        Protocol_SIM = model.ProtocolSIM,
                        Protocol_SN = model.ProtocolSN,
                        Protocol_Type = model.ProtocolType,
                        ProjectID = model.ProjectId,
                        Status = (int)model.Status
                    };
                    ent.GatewayInfo.AddObject(newinfo);
                    ent.SaveChanges();
                    model.ID = newinfo.ID;
                    return true;
                }

            }
            catch (System.Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }
    }
}
