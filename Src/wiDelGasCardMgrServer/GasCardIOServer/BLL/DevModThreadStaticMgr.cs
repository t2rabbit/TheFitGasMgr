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

namespace IOServer.BLL
{


    ////
    //// 系统通信对象管理；通信对象指的是需要保证无异常的对象可以是硬件也可以是软件线程如：下位机设备，采集线程，数据上传线程等
    ////
    //public class DevModThreadStaticMgr
    //{

    //    static private DevModThreadStaticMgr m_pInst;
    //    public Dictionary<long?, cnwlcs_communicationobject> m_dictionaryCommObjs = new Dictionary<long?, cnwlcs_communicationobject>();
    //    public Dictionary<long?, cnwlcs_communicationobject> m_dictionaryDevCommObjs = new Dictionary<long?, cnwlcs_communicationobject>();
    //    public Dictionary<long?, cnwlcs_communicationobject> m_dictionaryModCommObjs = new Dictionary<long?, cnwlcs_communicationobject>();
    //    public Dictionary<long?, DateTime> m_dictionaryModSetRoute = new Dictionary<long?, DateTime>();

    //    public List<cnwlcs_communicationobject> m_lstCommOjb = null;

    //    protected DevModThreadStaticMgr()
    //    {
    //    }

    //    static public DevModThreadStaticMgr Get()
    //    {
    //        if (m_pInst == null)
    //        {
    //            m_pInst = new DevModThreadStaticMgr();
    //        }
    //        return m_pInst;
    //    }

    //    public void Init()
    //    {
    //        //
    //        // 模块最后一次设置路由
    //        //


    //        //
    //        // 把需要检测的内存对象加载到内存
    //        //
    //        using (cn_wlcsEntitiesSqlServer ent = new cn_wlcsEntitiesSqlServer())
    //        {
    //            m_lstCommOjb = new List<cnwlcs_communicationobject>();
    //            m_dictionaryCommObjs.Clear();
    //            m_dictionaryCommObjs.Clear();
    //            m_dictionaryDevCommObjs.Clear();
    //            m_dictionaryModCommObjs.Clear();
    //            m_dictionaryModSetRoute.Clear();

    //            foreach (cnwlcs_communicationobject aObj in ent.cnwlcs_communicationobject)
    //            {
    //                m_lstCommOjb.Add(aObj);

    //                aObj.iLastStatus = DBDefines.CommObjectStatus.iCommNotChecked;
    //                aObj.UpdateStatus = DBDefines.CommObjectStatus.strCommNotChecked;
    //                aObj.UpdateMsg = DBDefines.CommObjectStatusMsg.strCommNotChecked;

    //                m_dictionaryCommObjs.Add(aObj.ID, aObj);

    //                if (aObj.Cata1 == DBDefines.CommObjDef.E_CATA_1_DEVS && aObj.Cata2 == DBDefines.CommObjDef.E_CATA_2_PORT)
    //                {
    //                    m_dictionaryDevCommObjs.Add(aObj.DevID, aObj);
    //                }
    //                else if (aObj.Cata1 == DBDefines.CommObjDef.E_CATA_1_DEVS && aObj.Cata2 == DBDefines.CommObjDef.E_CATA_2_MODULE)
    //                {
    //                    m_dictionaryModCommObjs.Add(aObj.ModuleID, aObj);
    //                }
    //                else
    //                {

    //                }
    //            }
    //            ent.SaveChanges();

    //        }
            
    //    }


    //    /// <summary>
    //    ///     把所有内存数据更新到数据库
    //    /// </summary>
    //    public void UpdateMemStatusToDB()
    //    {
    //        using (cn_wlcsEntitiesSqlServer ent = new cn_wlcsEntitiesSqlServer())
    //        {
    //            List<cnwlcs_communicationobject> lstCommObj = ent.cnwlcs_communicationobject.ToList();

    //            int iSleep = 0;
    //            foreach (cnwlcs_communicationobject aObj in lstCommObj)
    //            {

    //                if (iSleep++ > 100)
    //                {
    //                    Thread.Sleep(100);
    //                    iSleep = 0;
    //                }

    //                if (!m_dictionaryCommObjs.ContainsKey(aObj.ID))
    //                {
    //                    continue;
    //                }
    //                cnwlcs_communicationobject aMemValObj = m_dictionaryCommObjs[aObj.ID];
    //                if (aObj.iLastStatus == aMemValObj.iLastStatus
    //                    && aMemValObj.UpdateTime.AddMinutes(30)>DateTime.Now)
    //                {
    //                    continue;
    //                }

    //                aObj.iLastStatus = aMemValObj.iLastStatus;
    //                aObj.UpdateMsg = aMemValObj.UpdateMsg;
    //                aObj.UpdateStatus = aMemValObj.UpdateStatus;
    //                aObj.UpdateTime = aMemValObj.UpdateTime;
    //            }

    //            ent.SaveChanges();
    //        }
    //    }

    //    public int GetCommObjIDByModuleID(int iModuleID)
    //    {

    //        if (m_dictionaryModCommObjs.Keys.Contains(iModuleID))
    //        {
    //            return m_dictionaryModCommObjs[iModuleID].ID;
    //        }
    //        return 0;
    //    }

    //    public int GetCommObjIDByDevID(int iDevID)
    //    {
    //        if (m_dictionaryDevCommObjs.Keys.Contains(iDevID))
    //        {
    //            return m_dictionaryDevCommObjs[iDevID].ID;
    //        }
    //        return 0;
    //    }

    //    public void ClearDicInfo()
    //    {
    //        m_dictionaryCommObjs.Clear();
    //    }

    //    public bool UpdateObjectLastCommTime(int id, string strMsg, int iStatus)
    //    {
    //        try
    //        {
    //            if (m_dictionaryCommObjs.Keys.Contains(id))
    //            {
    //                m_dictionaryCommObjs[id].UpdateTime = DateTime.Now;
    //                m_dictionaryCommObjs[id].UpdateMsg = strMsg;
    //                m_dictionaryCommObjs[id].UpdateStatus = iStatus.ToString();

    //                if (iStatus == 0)
    //                {

    //                    if (m_dictionaryCommObjs[id].iLastStatus == iStatus)
    //                    {
    //                        UpdateStatusToDB(m_dictionaryCommObjs[id]);
    //                        CommunicationLogDBOp.Add(new cnwlcs_communicationlog()
    //                        {
    //                            ObjectID = id,
    //                            UpdateMsg = strMsg,
    //                            UpdateStatus = iStatus,
    //                            UpdateTime = DateTime.Now,
    //                        });
    //                    }
    //                }
    //                else
    //                {
    //                    if (m_dictionaryCommObjs[id].iLastStatus != iStatus)
    //                    {
    //                        UpdateStatusToDB(m_dictionaryCommObjs[id]);
    //                        CommunicationLogDBOp.Add(new cnwlcs_communicationlog()
    //                        {
    //                            ObjectID = id,
    //                            UpdateMsg = strMsg,
    //                            UpdateStatus = iStatus,
    //                            UpdateTime = DateTime.Now,
    //                        });
    //                    }
    //                }

    //                m_dictionaryCommObjs[id].iLastStatus = iStatus;
    //                m_dictionaryCommObjs[id].dtLastUpStatus = DateTime.Now;
    //                return true;
    //            }
    //        }
    //        catch (System.Exception ex)
    //        {
    //            LogMgr.WriteLog(ex.Message);
    //            return false;
    //        }

    //        return false;
    //    }

    //    public bool GetLastCommObjectCommunicationTime(ref DateTime dtLast, 
    //        ref string strNewstStus, 
    //        ref string strNewstMsg,
    //        int id)
    //    {
    //        if (m_dictionaryCommObjs.Keys.Contains(id))
    //        {
    //            dtLast = (DateTime)(m_dictionaryCommObjs[id].UpdateTime);
    //            strNewstStus = m_dictionaryCommObjs[id].UpdateStatus;
    //            strNewstMsg = m_dictionaryCommObjs[id].UpdateMsg;
    //            return true;
    //        }

    //        return false;
    //    }

    //    private Thread m_pThread;
    //    private bool m_bRun;

    //    public void Start()
    //    {
    //        Stop();

    //        m_pThread = new Thread(new ThreadStart(_Run));
    //        m_bRun = true;
    //        m_pThread.Start();
    //    }

    //    public void Stop()
    //    {
    //        Program.AddDevMsg(MsgDirect.E_NONE, "COM OP MGR 线程停止", DateTime.Now.ToString());
    //        m_bRun = false;

    //        try
    //        {
    //            if (m_pThread != null)
    //            {
    //                m_bRun = false;
    //                m_pThread.Join(1000);
    //                if (m_pThread.IsAlive)
    //                {
    //                    m_pThread.Abort();
    //                }
    //            }
    //        }
    //        catch (System.Exception ex)
    //        {

    //        }
    //        finally
    //        {
    //            m_pThread = null;
    //        }
    //    }

    //    private void _Run()
    //    {
    //        DateTime dtLastInsertToDB = DateTime.Now.AddYears(-1000);
    //        int iDelay = 0;
    //        while (m_bRun)
    //        {
    //            if (dtLastInsertToDB.AddMinutes(10) < DateTime.Now)
    //            {
    //                CheckOnLineDevIsLive();
    //            }


    //            iDelay = 5;
    //            while (iDelay-- > 0 && m_bRun)
    //            {
    //                Thread.Sleep(1000);
    //            }
    //        }
    //    }

    //    private void UpdateStatusToDB(cnwlcs_communicationobject aLastStatus)
    //    {
    //        CommunicationobjectDBOp.Update(aLastStatus.ID, aLastStatus);
    //    }

    //    private void CheckOnLineDevIsLive()
    //    {
    //        for (int i = 0; i < m_lstCommOjb.Count; i++)
    //        {
    //            try
    //            {
    //                cnwlcs_communicationobject aOjb = m_lstCommOjb[i];
    //                if (aOjb.UpdateStatus == DBDefines.CommObjectStatus.strCommOnLine)
    //                {
    //                    if (aOjb.UpdateTime.AddMinutes(30) < DateTime.Now)
    //                    {
    //                        UpdateObjectLastCommTime(aOjb.ID, DBDefines.CommObjectStatusMsg.strCommOffLine, DBDefines.CommObjectStatus.iCommOffLine);
    //                    }
    //                }
    //            }
    //            catch (System.Exception ex)
    //            {
    //                return;
    //            }
    //        }
    //    }
    //}

}
