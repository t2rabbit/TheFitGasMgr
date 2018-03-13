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
    class MemNodeValueMgr
    {
        /// <summary>
        /// 单件实现
        /// </summary>
        protected MemNodeValueMgr() { }
        private static MemNodeValueMgr m_pInst;
        public static MemNodeValueMgr Get()
        {
            if (m_pInst == null)
            {
                m_pInst = new MemNodeValueMgr();
            }

            return m_pInst;
        }

        /// <summary>
        /// 节点数据的最后一个值
        /// </summary>
        private Dictionary<int, NodeLastValue> m_dicValues = new Dictionary<int, NodeLastValue>();
        
        /// <summary>
        /// 将要插入数据库的数据
        /// </summary>
        private List<HisNodeValue> lstNodeValPrepareAddToDb = new List<HisNodeValue>();

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

            // todo 判断节点存盘标志是否为变化存储，增幅存储等等...

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
        public void UpdateOrInserNodeLastValToDB()
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


        /// <summary>
        /// 准备需要插入数据库的节点数据,定时执行
        /// </summary>
        public void MakePrepareNodeValToDb()
        {
            lock (lstNodeValPrepareAddToDb)
            {
                foreach (var dicItem in m_dicValues)
                {
                    if (dicItem.Value.ValueFlag == (int)DbConstDefine.ValueFlag.ValueOk)
                    {
                        HisNodeValue aHisVal = new HisNodeValue()
                           {
                               ID = 0,
                               Value = (double)dicItem.Value.LastValue,
                               LogDt = dicItem.Value.LogDt,
                               NodeId = dicItem.Value.NodeId,
                               Flag = dicItem.Value.ValueFlag
                           };

                        lstNodeValPrepareAddToDb.Add(aHisVal);
                    }
                }
            }
        }

        public List<HisNodeValue> GetDataWillAddToDb()
        {
            List<HisNodeValue> lstVals = new List<HisNodeValue>();
            lock (lstNodeValPrepareAddToDb)
            {
                lstVals.AddRange(lstNodeValPrepareAddToDb);
                lstNodeValPrepareAddToDb.Clear();
            }
            return lstVals;
        }
    
    
    
    }
}
