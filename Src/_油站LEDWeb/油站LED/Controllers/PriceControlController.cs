using GlareLedSysBll;
using GlareSysEfDbAndModels;
using GLLedPublic;
using LmxPublic;
using OilStationLED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace OilStationLED.Controllers
{
    public class PriceControlController : Controller
    {
        public static string StrNodeId = "";
        //
        // GET: /PriceControl/

        public ActionResult Index(string nodeid)
        {
            if (Session["SuperUser"] == null && Session["OrgUser"] == null && Session["GroupUser"] == null && Session["ProjectUser"] == null && Session["DevUser"] == null)
            {
                return RedirectToAction("Index", "Login", null);
            }
            else
            {
                if (Session["SuperUser"] != null)
                {
                    SuperLoginedUserModel userInfo = (SuperLoginedUserModel)(Session["SuperUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                }
                if (Session["OrgUser"] != null)
                {
                    OrgLoginedUserModel userInfo = (OrgLoginedUserModel)(Session["OrgUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                }
                if (Session["GroupUser"] != null)
                {
                    GroupLoginedUserModel userInfo = (GroupLoginedUserModel)(Session["GroupUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                }
                if (Session["ProjectUser"] != null)
                {
                    ProjectLoginedUserModel userInfo = (ProjectLoginedUserModel)(Session["ProjectUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                }
                if (Session["DevUser"] != null)
                {
                    CommDevLoginedUserModel userInfo = (CommDevLoginedUserModel)(Session["DevUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                }
            }
            if (!string.IsNullOrWhiteSpace(nodeid))
            {
                StrNodeId = nodeid;
            }
            return View();
        }


        /// <summary>
        /// 展示油卡
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult List(string Method, string Key, string NodeId)
        {
            object objResult = null;
            try
            {
                List<ModelForGasCardWithCommInfo> list = new List<ModelForGasCardWithCommInfo>();
                if (string.IsNullOrWhiteSpace(NodeId))
                {
                    list = DataLoader.GetAllGasCardWithCommInfoList();
                    int page = string.IsNullOrWhiteSpace(Request["page"]) ? 1 : Int32.Parse(Request["page"]);
                    int rows = string.IsNullOrWhiteSpace(Request["rows"]) ? 1 : Int32.Parse(Request["rows"]);
                    string order = string.IsNullOrWhiteSpace(Request["order"]) ? "DESC" : Request["order"].ToUpper();
                    string sort = string.IsNullOrWhiteSpace(Request["sort"]) ? "Id" : Request["sort"];
                    IQueryable<GasCardWithCommInfo> query = CommonTools.DataSorting<GasCardWithCommInfo>(list.AsQueryable(), sort, order).Skip((page - 1) * rows).Take(rows);
                    objResult = new { total = list.Count, rows = query };
                }
                else
                {
                    string[] strNodeIdSplit = NodeId.Split('_');
                    string strType = strNodeIdSplit[0];

                    string strId = strNodeIdSplit[1];
                    int iId = DataFormat.ConvertDBNullToInt32(strId);
                    using (LedDb db = new LedDb())
                    {
                        if (Method == "FirstLoad")
                        {
                            if (string.IsNullOrWhiteSpace(NodeId))
                            {
                                list = DataLoader.GetAllGasCardWithCommInfoList();
                            }
                            else
                            {
                                if (strType == "org")
                                {
                                    list = DataLoader.GetGasCardWithCommInfoByOrgId(strId);
                                }
                                else if (strType == "group")
                                {
                                    list = DataLoader.GetGasCardWithCommInfoByGorupID(strId);
                                }
                                else if (strType == "project")
                                {
                                    list = DataLoader.GetGasCardWithCommInfoByProjectID(strId);
                                }
                            }
                        }
                        else if (Method == "SearchLoad")
                        {
                            //list = db.GasCardWithCommInfo.Where(p => p.Name.Contains(Key) && p.IsDel != 1).ToList();
                        }
                        int page = string.IsNullOrWhiteSpace(Request["page"]) ? 1 : Int32.Parse(Request["page"]);
                        int rows = string.IsNullOrWhiteSpace(Request["rows"]) ? 1 : Int32.Parse(Request["rows"]);
                        string order = string.IsNullOrWhiteSpace(Request["order"]) ? "DESC" : Request["order"].ToUpper();
                        string sort = string.IsNullOrWhiteSpace(Request["sort"]) ? "Id" : Request["sort"];
                        IQueryable<GasCardWithCommInfo> query = CommonTools.DataSorting<GasCardWithCommInfo>(list.AsQueryable(), sort, order).Skip((page - 1) * rows).Take(rows);
                        objResult = new { total = list.Count, rows = query };
                    }
                }

            }
            catch (Exception ex)
            {
                objResult = new ResultHelper()
                {
                    Desc = ex.Message,
                    Msg = ex.Message,
                    Obj = null,
                    Ret = -1,
                    Status = false
                };
                //throw;
            }
            return Json(objResult);
        }


        /// <summary>
        /// Add 油卡
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(GasCardWithCommInfo subject)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        subject.UpdateDt = DateTime.Now;
                        subject.CreateDt = DateTime.Now;
                        subject.IsDel = 0;
                        db.GasCardWithCommInfo.Add(subject);
                        if (db.SaveChanges() > 0)
                        {
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = subject,
                                Msg = "Add  Success!",
                                Desc = "Add  Success!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Add  Faile,please try again.",
                                Msg = "Add  Faile,please try again.",
                                Obj = null,
                                Ret = -1,
                                Status = false
                            };
                        }
                    }
                    else
                    {
                        objResult = new ResultHelper()
                        {
                            Desc = " Faile,please try again",
                            Msg = " Faile,please try again",
                            Obj = null,
                            Ret = -1,
                            Status = false
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                objResult = new ResultHelper()
                {
                    Desc = ex.Message,
                    Msg = ex.Message,
                    Obj = null,
                    Ret = -1,
                    Status = false
                };
            }
            return Json(objResult);
        }

        /// <summary>
        /// Upadate 油卡
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Modify(GasCardWithCommInfo subject)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        GasCardWithCommInfo aSubject = db.GasCardWithCommInfo.Where(p => p.Id == subject.Id).FirstOrDefault();
                        //aSubject.CardName = subject.CardName;
                        //aSubject.CardModel = subject.CardModel;
                        //aSubject.ScreenCount = subject.ScreenCount;
                        //aSubject.ScreenNams = subject.ScreenNams;
                        aSubject = subject;
                        aSubject.UpdateDt = DateTime.Now;
                        if (db.SaveChanges() > 0)
                        {

                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = subject,
                                Msg = "Edit Success!",
                                Desc = "Edit Success!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Edit Faile,please try again.",
                                Msg = "Edit Faile,please try again.",
                                Obj = null,
                                Ret = -1,
                                Status = false
                            };
                        }
                    }
                    else
                    {
                        objResult = new ResultHelper()
                        {
                            Desc = " Faile,please try again",
                            Msg = " Faile,please try again",
                            Obj = null,
                            Ret = -1,
                            Status = false
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                objResult = new ResultHelper()
                {
                    Desc = ex.Message,
                    Msg = ex.Message,
                    Obj = null,
                    Ret = -1,
                    Status = false
                };
            }
            return Json(objResult);
        }


        /// <summary>
        /// Delete油卡
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string SubjectIDs)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.AppendFormat(@"UPDATE GasCardWithCommInfo SET IsDel = 1 WHERE Id IN ({0})", SubjectIDs);
                        if (db.Database.ExecuteSqlCommand(strSql.ToString()) > 0)
                        {
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = SubjectIDs,
                                Msg = "Delete Success!",
                                Desc = "Delete Success!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Delete Faile,please try again.",
                                Msg = "Delete Faile,please try again.",
                                Obj = null,
                                Ret = -1,
                                Status = false
                            };
                        }
                    }
                    else
                    {
                        objResult = new ResultHelper()
                        {
                            Desc = " Faile,please try again",
                            Msg = " Faile,please try again",
                            Obj = null,
                            Ret = -1,
                            Status = false
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                objResult = new ResultHelper()
                {
                    Desc = ex.Message,
                    Msg = ex.Message,
                    Obj = null,
                    Ret = -1,
                    Status = false
                };
            }
            return Json(objResult);
        }

        /// <summary>
        /// Batch Save油价
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveBatchOilPrice(string Price1, string Price2, string Price3, string Price4,
            string Price5, string Price6, string Price7, string Price8, string Price9, string Price10,
            string Price11, string Price12, string BatchIds)
        {
            ResultHelper objResult = null;
            try
            {
                string Context = Price1 + "-" + Price2 + "-" + Price3 + "-" + Price4 + "-" + Price5 + "-" + Price6 + "-"
                    + Price7 + "-" + Price8 + "-" + Price9 + "-" + Price10 + "-" + Price11 + "-" + Price12;
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.AppendFormat(@"UPDATE GasCardWithCommInfo SET CardContext = {0} WHERE Id IN ({1})", Context, BatchIds);
                        if (db.Database.ExecuteSqlCommand(strSql.ToString()) > 0)
                        {
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = BatchIds,
                                Msg = "Batch Upadate  Success!",
                                Desc = "Batch Upadate  Success!"
                            };
                            string[] id = BatchIds.Split(',');
                            for (int i = 0; i < id.Length; i++)
                            {
                                int iID = DataFormat.ConvertDBNullToInt32(id[i]);
                                SendCMD(iID, Context);
                            }
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Batch Upadate  Faile,please try again.",
                                Msg = "Batch Upadate  Faile,please try again.",
                                Obj = null,
                                Ret = -1,
                                Status = false
                            };
                        }
                    }
                    else
                    {
                        objResult = new ResultHelper()
                        {
                            Desc = " Faile,please try again",
                            Msg = " Faile,please try again",
                            Obj = null,
                            Ret = -1,
                            Status = false
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                objResult = new ResultHelper()
                {
                    Desc = ex.Message,
                    Msg = ex.Message,
                    Obj = null,
                    Ret = -1,
                    Status = false
                };
            }
            return Json(objResult);
        }

        public bool SendCMD(int id, string value)
        {
            bool bSend = false;
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                using (LedDb db = new LedDb())
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
                    bSend = CmdLogsBll.AddCommDevInfo(ref aLog, out strError);

                    bSend = InsertCmdToMemcached(aLog.Id);
                    if (bSend)
                    {
                        for (int i = 1; i < 10; i++)
                        {
                            Thread.Sleep(1000);
                            if (RemoveCmdHandledInMemcached(aLog.Id))
                            {
                                bSend = true;
                                break;
                            }
                        }
                    }

                }
            }
            else
            {
                bSend = false;
            }
            return bSend;
        }

        private bool InsertCmdToMemcached(int id)
        {
            string strIds = PiPublic.MemcachedMgr.GetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd);
            if (strIds.Length == 0)
            {
                PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, id.ToString());
            }

            strIds += id.ToString();
            if (strIds.Length > 0)
            {
                strIds += ",";
            }

            return PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, strIds);
        }

        private bool RemoveCmdHandledInMemcached(int id)
        {
            bool bFind = false;

            string strIds = PiPublic.MemcachedMgr.GetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyCmdResult);
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

                strNewIds += str;
                if (strNewIds.Length > 0)
                {
                    strNewIds += ",";
                }
            }
            PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, strNewIds);
            return bFind;
        }
    }
}
