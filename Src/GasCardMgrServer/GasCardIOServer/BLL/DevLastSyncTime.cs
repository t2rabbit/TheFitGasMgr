using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace IOServer.BLL
{
    /// <summary>
    /// 网关最后一次同步时间
    /// </summary>
    class GwLastSyncTimeMgr
    {
        private GwLastSyncTimeMgr() { }
        private static GwLastSyncTimeMgr m_pInst;
        public static GwLastSyncTimeMgr Get()
        {
            if (m_pInst == null)
            {
                m_pInst = new GwLastSyncTimeMgr();
            }
            return m_pInst;
        }
        
        public Dictionary<int, DateTime> mapLastGwSyncTime = new Dictionary<int, DateTime>();
        public void Init()
        {
            foreach (DevInfoModel item in DBMgr.Get().LstPortGaweway)
	        {
                //m_dictionaryModLastTime.Add(item.ID, DateTime.Now.AddYears(-1000));
                string strKey = string.Format("{0}_{1}", item.GroupId, item.DevAddr);
                if (m_dicDevLastVal.ContainsKey(strKey))
                {
                    continue;
                }
                else
                {
                    m_dicDevLastVal.Add(strKey, new DateTime(2000, 1, 1));
                }

	        }
        }

        public DateTime GetLastTime(string strKey)
        {
            if (m_dicDevLastVal.ContainsKey(strKey))
            {
                return m_dicDevLastVal[strKey];
            }
            return DateTime.Now.AddYears(-1000);
        }

        public void SetLastTime(string strKey)
        {
            if (m_dicDevLastVal.ContainsKey(strKey))
            {
                m_dicDevLastVal[strKey] = DateTime.Now;
                return;
            }
                
            m_dicDevLastVal.Add(strKey, DateTime.Now);
        }
    }
}
