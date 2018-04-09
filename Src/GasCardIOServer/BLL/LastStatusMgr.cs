using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using NetLabelEfDbDll;
using NetLabelEfDbDll.SqlServer;
using PiPublic.Log;

namespace IOServer.BLL
{
    //
    // 状态管理
    // 需要保证无异常的对象可以是硬件也可以是软件线程如：
    // 通信网关，下位机设备，采集线程，数据上传线程等
    //
    public class LastStatusMgr
    {
        static private LastStatusMgr m_pInst;
        public Dictionary<int, LastStatusInfo> mapGwStatus = new Dictionary<int, LastStatusInfo>();
        public Dictionary<int, LastStatusInfo> mapModelStatus= new Dictionary<int, LastStatusInfo>();
        
        private List<LastStatusInfo> lstModelStatusAddToDb = new List<LastStatusInfo>();
        private List<LastStatusInfo> lastGwStateAddToDb = new List<LastStatusInfo>();


        protected LastStatusMgr()
        {
        }

        static public LastStatusMgr Get()
        {
            if (m_pInst == null)
            {
                m_pInst = new LastStatusMgr();
            }
            return m_pInst;
        }

        
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {            
            //
            // 把需要检测的内存对象加载到内存
            //
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                foreach (DevInfo adev in ent.DevInfo)
                {
                    LastStatusInfo aobj = new LastStatusInfo()
                    {
                        DevId = adev.ID,
                        GatewayId = 0,
                        Status = (int)LastStatusInfo.EStatus.ESOffLine,
                        ThreadName = "",
                        TypeInfo = LastStatusInfo.ETypeInfo.ETDev,
                        UpdateDt = DateTime.Now
                    };

                    mapModelStatus.Add(adev.ID, aobj);
                }


                foreach (GatewayInfo adev in ent.GatewayInfo)
                {
                    LastStatusInfo aobj = new LastStatusInfo()
                    {
                        DevId = 0,
                        GatewayId = adev.ID,
                        Status = (int)LastStatusInfo.EStatus.ESOffLine,
                        ThreadName = "",
                        TypeInfo = LastStatusInfo.ETypeInfo.ETGateway,
                        UpdateDt = DateTime.Now
                    };

                    mapGwStatus.Add(adev.ID, aobj);
                }
            }

        }


        /// <summary>
        ///  把所有内存数据更新到数据库
        /// </summary>
        public void SaveMemStatusToDB()
        {
            HlpSaveGwMemStatusToDb();
            HlpSaveModelMemStatusToDb();
        }

        /// <summary>
        /// 在线的状态是否还是有效的
        /// </summary>
        public void CheckStatusIsLive()
        {
            HlperCheckGwStatusIsLive();
            HlperCheckDevStatusIsLive();
        }


        public LastStatusInfo.EStatus GetGwStatus(int iID, out DateTime dtUpdate)
        {
            dtUpdate = new DateTime(2000,1,1);
            if (!mapGwStatus.ContainsKey(iID))
            {
                return LastStatusInfo.EStatus.ESOffLine;
            }

            dtUpdate = mapGwStatus[iID].UpdateDt;
            return mapGwStatus[iID].Status;
        }

        public LastStatusInfo.EStatus GetModelStatus(int iID, out DateTime dtUpdate)
        {
            dtUpdate = new DateTime(2000, 1, 1);
            if (!mapModelStatus.ContainsKey(iID))
            {
                return LastStatusInfo.EStatus.ESOffLine;
            }

            dtUpdate = mapModelStatus[iID].UpdateDt;
            return mapModelStatus[iID].Status;
        }


        public void UpdateGwStatusToMem(int iGwid, LastStatusInfo.EStatus status)
        {
            if (!mapGwStatus.ContainsKey(iGwid))
            {
                LogMgr.WriteErrorDefSys("gw 的ID 不存在");
                return;
            }

            LastStatusInfo info = mapGwStatus[iGwid];
            //
            // todo 状态改变需要添加到日志里面
            //
            info.Status = status;
            info.UpdateDt = DateTime.Now;
        }

        public void UpdateDevStatusToMem(int iDevId, LastStatusInfo.EStatus status)
        {
            if (!mapModelStatus.ContainsKey(iDevId))
            {
                LogMgr.WriteErrorDefSys("dev 的ID 不存在");
                return;
            }
            LastStatusInfo info = mapModelStatus[iDevId];
            //
            // todo 状态改变需要添加到日志里面
            //
            info.Status = status;
            info.UpdateDt = DateTime.Now;
        }

        private void HlpSaveGwMemStatusToDb()
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                List<GatewayStatus> lstCommObj = ent.GatewayStatus.ToList();               

                foreach (var aObj in mapGwStatus)
                {
                    GatewayStatus gwStatusInDb = lstCommObj.Find(cc=>cc.GatewayId == aObj.Key);
                    if (gwStatusInDb == null)
                    {
                        ent.GatewayStatus.AddObject(new GatewayStatus()
                        {
                            ID = 0,
                            GatewayId = aObj.Value.GatewayId,
                            LogDt = aObj.Value.UpdateDt,
                            Status = (int)aObj.Value.Status
                        });
                    }
                    else
                    {
                        gwStatusInDb.Status = (int)aObj.Value.Status;
                        gwStatusInDb.LogDt = aObj.Value.UpdateDt;
                    }
                }
                ent.SaveChanges();
            }
        }

        
        /// <summary>
        /// 保存模块状态到数据库
        /// </summary>
        private void HlpSaveModelMemStatusToDb()
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                List<DevStatus> lstCommObj = ent.DevStatus.ToList();               

                foreach (var aObj in mapModelStatus)
                {
                    DevStatus gwStatusInDb = lstCommObj.Find(cc=>cc.DevId == aObj.Key);
                    if (gwStatusInDb == null)
                    {
                        ent.DevStatus.AddObject(new DevStatus()
                        {
                            ID = 0,
                            DevId = aObj.Value.DevId,
                            LogDt = aObj.Value.UpdateDt,
                            Status = (int)aObj.Value.Status
                        });
                    }
                    else
                    {
                        gwStatusInDb.Status = (int)aObj.Value.Status;
                        gwStatusInDb.LogDt = aObj.Value.UpdateDt;
                    }
                }



                ent.SaveChanges();
            }
        }

        private void HlperCheckGwStatusIsLive()
        {
            foreach (var aobj in mapGwStatus)
            {
                if (aobj.Value.Status == LastStatusInfo.EStatus.ESOnLine)
                {
                    if (aobj.Value.UpdateDt.AddSeconds(CfgMgr.GetGetDevDataRate() * 3) < DateTime.Now)
                    {
                        aobj.Value.UpdateDt = DateTime.Now;
                        aobj.Value.Status = LastStatusInfo.EStatus.ESOffLine;
                    }
                }
            }
        }

        private void HlperCheckDevStatusIsLive()
        {
            foreach (var aobj in mapModelStatus)
            {
                if (aobj.Value.Status == LastStatusInfo.EStatus.ESOnLine)
                {
                    if (aobj.Value.UpdateDt.AddSeconds(CfgMgr.GetGetDevDataRate() * 3) < DateTime.Now)
                    {
                        aobj.Value.UpdateDt = DateTime.Now;
                        aobj.Value.Status = LastStatusInfo.EStatus.ESOffLine;
                    }
                }
            }
        }
    }

}
