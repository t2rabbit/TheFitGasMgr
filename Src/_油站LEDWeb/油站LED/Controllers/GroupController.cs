using GlareLedSysBll;
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
    public class GroupController : Controller
    {
        //
        // GET: /Group/

        public ActionResult Index()
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
            return View();
        }


        /// <summary>
        /// 展示Org
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult List(string Method, string Key)
        {
            object objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    List<ModelForGroupInfo> list = new List<ModelForGroupInfo>();
                    if (Method == "FirstLoad")
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append(@"select
                                        g.*,
                                        o.Name OrgName
                                        from 
                                        GroupInfo g
                                        left join OrgInfo o on o.Id=g.OrgId
                                        where g.IsDel!=1 or g.IsDel is null");
                        list = db.Database.SqlQuery<ModelForGroupInfo>(strSql.ToString()).ToList();
                    }
                    else if (Method == "SearchLoad")
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.AppendFormat(@"select
                                            g.*,
                                            o.Name OrgName
                                            from 
                                            GroupInfo g
                                            left join OrgInfo o on o.Id=g.OrgId
                                            where g.IsDel!=1
                                            and g.Name like '%{0}%'",Key);
                        list = db.Database.SqlQuery<ModelForGroupInfo>(strSql.ToString()).ToList();
                    }
                    int page = string.IsNullOrWhiteSpace(Request["page"]) ? 1 : Int32.Parse(Request["page"]);
                    int rows = string.IsNullOrWhiteSpace(Request["rows"]) ? 1 : Int32.Parse(Request["rows"]);
                    string order = string.IsNullOrWhiteSpace(Request["order"]) ? "DESC" : Request["order"].ToUpper();
                    string sort = string.IsNullOrWhiteSpace(Request["sort"]) ? "Id" : Request["sort"];
                    IQueryable<GroupInfo> query = CommonTools.DataSorting<GroupInfo>(list.AsQueryable(), sort, order).Skip((page - 1) * rows).Take(rows);
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
        /// ListOrg
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ListOrg()
        {
            object objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"select
                                    o.Id ID,
                                    o.Name Name
                                    from OrgInfo o
                                    where o.IsDel!=1");
                    List<ModelForIDAndName> list = db.Database.SqlQuery<ModelForIDAndName>(strSql.ToString()).ToList();
                    objResult = list;
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
        /// Add Org
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(GlareSysEfDbAndModels.GroupInfo subject)
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
                        string strMsg = string.Empty;
                        bool b = GroupBll.AddAGroup(ref subject, out strMsg);
                        if (b)
                        {
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = subject,
                                Msg = strMsg,
                                Desc = strMsg
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = strMsg,
                                Msg = strMsg,
                                Obj = null,
                                Ret = -1,
                                Status = false
                            };
                        }
                        //db.GroupInfo.Add(subject);
                        //if (db.SaveChanges() > 0)
                        //{

                        //    objResult = new ResultHelper()
                        //    {
                        //        Status = true,
                        //        Ret = 0,
                        //        Obj = subject,
                        //        Msg = "Add  Success!",
                        //        Desc = "Add  Success!"
                        //    };
                        //}
                        //else
                        //{
                        //    objResult = new ResultHelper()
                        //    {
                        //        Desc = "Add  Faile,please try again.",
                        //        Msg = "Add  Faile,please try again.",
                        //        Obj = null,
                        //        Ret = -1,
                        //        Status = false
                        //    };
                        //}
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
        /// Upadate Org
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Modify(GlareSysEfDbAndModels.GroupInfo subject)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        GroupInfo aSubject = db.GroupInfo.Where(p => p.Id == subject.Id).FirstOrDefault();
                        aSubject.GroupName = subject.GroupName;
                        aSubject.GroupAddress = subject.GroupAddress;
                        aSubject.ManageName = subject.ManageName;
                        aSubject.ManageTel = subject.ManageTel;
                        aSubject.OrgId = subject.OrgId;
                        aSubject.UpdateDt = DateTime.Now;

                        string strMsg = string.Empty;
                        bool b = GroupBll.UpdateProejct(ref subject, out strMsg);
                        if (b)
                        {
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = subject,
                                Msg = strMsg,
                                Desc = strMsg
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = strMsg,
                                Msg = strMsg,
                                Obj = null,
                                Ret = -1,
                                Status = false
                            };
                        }
                        //if (db.SaveChanges() > 0)
                        //{

                        //    objResult = new ResultHelper()
                        //    {
                        //        Status = true,
                        //        Ret = 0,
                        //        Obj = subject,
                        //        Msg = "Edit Success!",
                        //        Desc = "Edit Success!"
                        //    };
                        //}
                        //else
                        //{
                        //    objResult = new ResultHelper()
                        //    {
                        //        Desc = "Edit Faile,please try again.",
                        //        Msg = "Edit Faile,please try again.",
                        //        Obj = null,
                        //        Ret = -1,
                        //        Status = false
                        //    };
                        //}
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
        /// DeleteOrg
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string GroupIds)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        string[] Id = GroupIds.Split(',');
                        string strMsg = string.Empty;
                        for (int i = 0; i < Id.Length; i++)
                        {
                            GroupBll.DeleteAGroup(int.Parse(Id[i]), out strMsg);
                        }
                        objResult = new ResultHelper()
                        {
                            Status = true,
                            Ret = 0,
                            Obj = GroupIds,
                            Msg = strMsg,
                            Desc = strMsg
                        };
                        //StringBuilder strSql = new StringBuilder();
                        //strSql.AppendFormat(@"UPDATE GroupInfo SET IsDel = 1 WHERE Id IN ({0})", GroupIds);
                        //if (db.Database.ExecuteSqlCommand(strSql.ToString()) > 0)
                        //{

                        //    objResult = new ResultHelper()
                        //    {
                        //        Status = true,
                        //        Ret = 0,
                        //        Obj = GroupIds,
                        //        Msg = "Delete Success!",
                        //        Desc = "Delete Success!"
                        //    };
                        //}
                        //else
                        //{
                        //    objResult = new ResultHelper()
                        //    {
                        //        Desc = "Delete Faile,please try again.",
                        //        Msg = "Delete Faile,please try again.",
                        //        Obj = null,
                        //        Ret = -1,
                        //        Status = false
                        //    };
                        //}
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


    }
}
