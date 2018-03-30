using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YDesmsPublicDefDll;
using PiPublic;
using System.IO;
using PiPublic.Log;

namespace Property
{
    class DataCenterObject
    {
        //
		// 单件
		//
		#region 单件定义
			protected DataCenterObject() { }
			static private DataCenterObject m_pInst;
			
			static public DataCenterObject Get()
			{
				if (m_pInst == null)
				{
					m_pInst = new DataCenterObject();
				}
				return m_pInst;
			}
		#endregion

        // 初始化
        public void Init()
        {
            m_pGwServerPort.Port = ConstDef.CenterForOrgPort;
        }

        // 启动
        public bool Start()
        {
            LogMgr.WriteLog("DC", DBDefines.CLogTypeDefine.TYPE_INFO, DBDefines.CLogLevelDefine.LEVEL_INFO, "数据中心启动");
            m_pGwServerPort.Start();
            return true;
        }

        public void Stop()
        {
            m_pGwServerPort.Stop();
        }

        //
        // 属性
        //
        public GWListenPort m_pGwServerPort = new GWListenPort(); // TCP监听端口        
        public Dictionary<long, OrgClientStaticInfo> m_dicGateStatics = new Dictionary<long, OrgClientStaticInfo>(); //  状态统计

        public OrgClientStaticInfo GetClientStat(long iGateid)
        {
            if (m_dicGateStatics.Keys.Contains(iGateid))
            {
                OrgClientStaticInfo info = m_dicGateStatics[iGateid];
                return info;                
            }
            return null;
        }

        public void AddConnTime(long iGateid)
        {
            if (m_dicGateStatics.Keys.Contains(iGateid))
            {
                OrgClientStaticInfo info = m_dicGateStatics[iGateid];
                info.recontimes++;
                info.dtLastConn = DateTime.Now;
            }
        }

        public void SetConnStatus(long iGateid, int ConnSta)
        {
            if (m_dicGateStatics.Keys.Contains(iGateid))
            {
                OrgClientStaticInfo info = m_dicGateStatics[iGateid];
                info.curstat = ConnSta;
            }
        }

        public void AddCommTimeNoCheck(long iGateid)
        {
            if (m_dicGateStatics.Keys.Contains(iGateid))
            {
                OrgClientStaticInfo info = m_dicGateStatics[iGateid];
                info.commtime++;              
            }
        }


        public void AddCommSuccessTime(long iGateid)
        {
            if (m_dicGateStatics.Keys.Contains(iGateid))
            {
                OrgClientStaticInfo info = m_dicGateStatics[iGateid];                
                info.commsuccess++;
                info.dtLastComm = DateTime.Now;
                
            }
        }
    }
}
