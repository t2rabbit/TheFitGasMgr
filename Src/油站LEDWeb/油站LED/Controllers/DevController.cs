using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LmxPublic;
using GlareLedSysBll;
using GLLedPublic;
using System.Threading;

namespace OilStationLED.Controllers
{
    public class DevController : Controller
    {
        //
        // GET: /Dev/
      
        public ActionResult Index()
        {
            
            return View();
        }


        /// <summary>
        /// 获取油站信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetGasCardInfo(int id)
        {
            object objResult = null;
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                using (LedDbEntities db = new LedDbEntities())
                {
                    GasCardWithCommInfo aGasCardInfo = db.GasCardWithCommInfo.Where(p => p.Id == id && p.IsDel != 1).FirstOrDefault();
                    if (aGasCardInfo != null)
                    {
                        objResult = new ResultHelper()
                        {
                            Desc = "油站信息获取成功",
                            Msg = "油站信息获取成功",
                            Obj = aGasCardInfo,
                            Ret = 1,
                            Status = true
                        };
                    }
                    else
                    {
                        objResult = new ResultHelper()
                        {
                            Status = false,
                            Ret = -1,
                            Obj = null,
                            Msg = "不存在此记录",
                            Desc = "不存在此记录"
                        };
                    }
                }
            }
            else
            {
                objResult = new ResultHelper()
                {
                    Status = false,
                    Ret = -1,
                    Obj = null,
                    Msg = "id为空,请稍后再试",
                    Desc = "id为空,请稍后再试"
                };
            }
            return Json(objResult);
        }

        private bool InsertCmdToMemcached(int id)
        {
            string strIds = PiPublic.MemcachedMgr.GetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd);
            if (strIds.Length == 0)
            {
                PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, id.ToString());
            }


            if (strIds.Length > 0)
            {
                strIds += ",";
                strIds += id.ToString();
            }
            
            return PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, strIds);
        }

        private bool RemoveCmdHandledInMemcached(int id)
        {
            bool bFind = false;

            string strIds = PiPublic.MemcachedMgr.GetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd);
            if (strIds.Length == 0)
            {
                return false;
            }
                    

            string[] arrIds = strIds.Split(new char[] { '-', ',' });
            string strNewIds = "";
            foreach (var str in arrIds)
            {
                if (str == id.ToString())
                {
                    bFind = true;
                    continue;
                }

                if (strNewIds.Length > 0)
                {
                    strNewIds += ",";
                    strNewIds += str;
                }
            }
            PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, strNewIds);
            return bFind;
        }


        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SendCMD(int id, string value)
        {
            object objResult = null;
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                using (LedDbEntities db = new LedDbEntities())
                {
                    string strError = string.Empty;
                    GlareSysEfDbAndModels.CmdLogs aLog = new GlareSysEfDbAndModels.CmdLogs()
                    {
                        CardInfoId = id,
                        CmdInfo = value,
                        CmdType = GlareLedSysDefPub.CmdDefSetOilValue,
                        CommDevId = id,
                        CreateTime = DateTime.Now,
                        IsDetele = 0,
                        Result = 0,
                        ResultInfo = "",
                        UpdateTime = DateTime.Now
                    };
                    bool bSend = CmdLogsBll.AddCommDevInfo(ref aLog,out strError);

                    bSend = InsertCmdToMemcached(aLog.Id);
                    bool bRecived = false;
                    if (bSend)
                    {
                        for(int i=1;i<10; i++)
                        {
                            Thread.Sleep(1000);
                            if (RemoveCmdHandledInMemcached(aLog.Id))
                            {
                                bRecived = true;
                                break;
                            }
                        }
                    }
                    
                    if (bRecived)
                    {
                        objResult = new ResultHelper()
                        {
                            Desc = "命令下发成功",
                            Msg = "命令下发成功",
                            Obj = aLog,
                            Ret = 1,
                            Status = true
                        };
                    }
                    else
                    {
                        objResult = new ResultHelper()
                        {
                            Status = false,
                            Ret = -1,
                            Obj = null,
                            Msg = strError,
                            Desc = strError
                        };
                    }
                }
            }
            else
            {
                objResult = new ResultHelper()
                {
                    Status = false,
                    Ret = -1,
                    Obj = null,
                    Msg = "id为空,请稍后再试",
                    Desc = "id为空,请稍后再试"
                };
            }
            return Json(objResult);
        }
    }
}
