///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: RealValBll.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-25 21:27:05
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetLabelEfDbDll.SqlServer;

namespace NetLabelBll
{
    /// <summary>
    /// 实时数据，节点数据
    /// </summary>
    public class RealValBll
    {
        public List<RealtimeValueTable> GetRealValByConditions(string strCond, string strOrder)
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from RealtimeValueTable ");
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

                List<RealtimeValueTable> lstNodevals = 
                    ent.ExecuteStoreQuery<RealtimeValueTable>(sb.ToString()).ToList<RealtimeValueTable>();
                return lstNodevals;
            }
        }


        public List<RealtimeValueTable> GetRealValByDevId(int iDevId)
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                string strSql = string.Format(@"select tRt.* from RealtimeValueTable as tRt 
                                                left join NodeInfo as tNode on tRt.NodeId = tNode.ID
                                                where tNode.devid = {0)", iDevId);

                List<RealtimeValueTable> lstNodevals =
                    ent.ExecuteStoreQuery<RealtimeValueTable>(strSql.ToString()).ToList<RealtimeValueTable>();
                return lstNodevals;
            }
        }

    }
}
