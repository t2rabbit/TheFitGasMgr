using GlareSysEfDbAndModels;
using LmxPublic;
using OilStationLED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                string[] strNodeIdSplit = NodeId.Split('_');
                string strType = strNodeIdSplit[0];

                string strId = strNodeIdSplit[1];
                int iId = DataFormat.ConvertDBNullToInt32(strId);
                using (LedDbEntities db = new LedDbEntities())
                {
                    List<ModelForGasCardWithCommInfo> list = new List<ModelForGasCardWithCommInfo>();
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
        /// 添加油卡
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
                using (LedDbEntities db = new LedDbEntities())
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
                                Msg = "添加成功!",
                                Desc = "添加成功!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "添加失败,请重试.",
                                Msg = "添加失败,请重试.",
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
                            Desc = "系统出错,请重试.",
                            Msg = "系统出错,请重试.",
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
        /// 更新油卡
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
                using (LedDbEntities db = new LedDbEntities())
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
                                Msg = "修改成功!",
                                Desc = "修改成功!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "修改失败,请重试.",
                                Msg = "修改失败,请重试.",
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
                            Desc = "系统出错,请重试.",
                            Msg = "系统出错,请重试.",
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
        /// 删除油卡
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string SubjectIDs)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDbEntities db = new LedDbEntities())
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
                                Msg = "删除成功!",
                                Desc = "删除成功!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "删除失败,请重试.",
                                Msg = "删除失败,请重试.",
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
                            Desc = "系统出错,请重试.",
                            Msg = "系统出错,请重试.",
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
        /// 批量保存油价
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveBatchOilPrice(string Context, string BatchIds)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDbEntities db = new LedDbEntities())
                {
                    if (ModelState.IsValid)
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.AppendFormat(@"UPDATE GasCardWithCommInfo SET Context = {0} WHERE Id IN ({1})", Context, BatchIds);
                        if (db.Database.ExecuteSqlCommand(strSql.ToString()) > 0)
                        {
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = BatchIds,
                                Msg = "批量更新成功!",
                                Desc = "批量更新成功!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "批量更新失败,请重试.",
                                Msg = "批量更新失败,请重试.",
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
                            Desc = "系统出错,请重试.",
                            Msg = "系统出错,请重试.",
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
    }
}
