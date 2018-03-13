///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: NodeBll.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-24 21:06:07
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using NetLabelEfDbDll.SqlServer;

namespace NetLabelBll
{
    public class NodeBll
    {

        public static List<NodeInfoModel> GetAllNode()
        {
            List<NodeInfoModel> lstMods = new List<NodeInfoModel>();
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    List<NodeInfo> lstNodeObj = (from c in ent.NodeInfo select c).ToList();
                    foreach (NodeInfo item in lstNodeObj)
                    {
                        lstMods.Add(new NodeInfoModel()
                            {
                                DevId = (int)item.DevId,
                                ID = item.ID,
                                Name = item.Name,
                                strAddr = item.ResAddress,
                                strCatalog1 = item.ValueCatalog1,
                                strCatalog2 = item.ValueCatalog2,
                                strFuncCode = item.FunCode,
                            });
                    }                   
                }
            }
            catch (System.Exception ex)
            {
            }
            return lstMods;
        }

        public static bool AddNode(ref NodeInfoModel mod, out string strError)
        {
            strError = "";
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    NodeInfo obj = new NodeInfo()
                    {
                        DevId = mod.DevId,
                        FunCode = mod.strFuncCode,
                        ID = mod.ID,
                        Name = mod.Name,
                        ResAddress = mod.strAddr,
                        ValueCatalog1 = mod.strCatalog1,
                        ValueCatalog2 = mod.strCatalog2,
                    };
                    ent.NodeInfo.AddObject(obj);
                    ent.SaveChanges();
                    mod.ID = obj.ID;
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                strError = ex.Message;
            }
            return false;
        }

        public static bool DelNodeById(int iId)
        {
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    NodeInfo delobj = new NodeInfo()
                    {
                        ID = iId
                    };
                    ent.NodeInfo.Attach(delobj);
                    ent.NodeInfo.DeleteObject(delobj);
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (System.Exception ex)
            {                
                return false;
            }
        }
    }
}
