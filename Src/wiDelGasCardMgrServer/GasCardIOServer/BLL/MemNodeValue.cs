using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NetLabelEfDbDll.SqlServer;
using Models;
using NetLabelEfDbDll;

namespace IOServer.BLL
{
    //
    // 内存节点数据
    //
    class MemNodeValue
    {
        protected MemNodeValue() { }
        private static MemNodeValue m_pInst;
        public static MemNodeValue Get()
        {
            if (m_pInst == null)
            {
                m_pInst = new MemNodeValue();
            }

            return m_pInst;
        }
        Dictionary<int, NodeLastValue> m_dicValues = new Dictionary<int, NodeLastValue>();

        public void Init()
        {
            m_dicValues.Clear();
            List<int> lstIDInDB = new List<int>();
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                List<NodeLastValue> lstNodeValInDb = ent.NodeLastValue.ToList();
                foreach (NodeInfoModel aNode in DBMgr.Get().ListNode)
                {
                    NodeLastValue aNodeLastValue = new NodeLastValue()
                    {
                        ID = aNode.ID,
                        NodeId  = aNode.ID,
                        LogDt = DateTime.Now.AddYears(-10),
                          
                        LastValue = 0,
                        ValueFlag = (int)DbConstDefine.ValueFlag.ValueNotInit,
                    };
                    NodeLastValue lastValueInDb = (from c in lstNodeValInDb
                                                   where c.NodeId == aNode.ID
                                                   select c).FirstOrDefault();
                    if (lastValueInDb != null)
                    {
                        aNodeLastValue.LastValue = lastValueInDb.LastValue;
                    }
                    m_dicValues.Add(aNode.ID, aNodeLastValue);
                }
            }

        }


        /// <summary>
        /// 设置节点的最新值
        /// </summary>
        /// <param name="iNodeID"></param>
        /// <param name="fValue"></param>
        /// <param name="dtLogDT"></param>
        /// <param name="iValFlag"></param>
        /// <returns></returns>
        public bool UpdateNewstValueInMem(int iNodeID, float fValue, DateTime dtLogDT, int iValFlag)
        {
            if (!m_dicValues.Keys.Contains(iNodeID))
            {
                System.Diagnostics.Debug.Assert(false);
                return false;
            }
            m_dicValues[iNodeID].LastValue = (decimal)fValue;
            m_dicValues[iNodeID].LogDt = dtLogDT;
            m_dicValues[iNodeID].ValueFlag = iValFlag;

            return true;
        }

        /// <summary>
        /// 获取最新的值
        /// </summary>
        /// <param name="iNodeID"></param>
        /// <param name="fValue"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool GetANewstValueByMem(int iNodeID, out float fValue, out DateTime dt)
        {
            fValue = 0;
            dt = DateTime.Now.AddYears(-1);

            if (!m_dicValues.Keys.Contains(iNodeID))
            {
                System.Diagnostics.Debug.Assert(false);
                return false;
            }

            NodeLastValue aLastValue = m_dicValues[iNodeID];            
            fValue = (float)m_dicValues[iNodeID].LastValue;
            dt = (DateTime)aLastValue.LogDt;            
            return true;
        }


        /// <summary>
        /// 把数据更新到内存
        /// </summary>
        public void UpdateOrInserValToDB()
        {    
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    // todo 
                    List<NodeLastValue> lstNodeVal = ent.NodeLastValue.ToList();
                    foreach (var dicItem in m_dicValues)
                    {
                        NodeLastValue lastVal = dicItem.Value;
                        NodeLastValue lastValInDb = (from c in lstNodeVal 
                                                     where c.NodeId == dicItem.Key 
                                                     select c).FirstOrDefault();
                        if (lastValInDb == null)
                        {
                            ent.NodeLastValue.AddObject(new NodeLastValue()
                                {
                                    ID = 0,
                                    LastValue = lastVal.LastValue,
                                    LogDt = lastVal.LogDt,
                                    NodeId = lastVal.NodeId,
                                    ValueFlag = lastVal.ValueFlag
                                });
                        }
                        else
                        {
                            lastValInDb.LogDt = lastVal.LogDt;
                            lastValInDb.LastValue = lastVal.LastValue;
                            lastValInDb.ValueFlag = lastVal.ValueFlag;
                        }
                    }                  
                    ent.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
            	
            }            
        }
    }
}
