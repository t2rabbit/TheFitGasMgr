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
    public class ProjectController : Controller
    {
        //
        // GET: /Project/

        public ActionResult Index()
        {
            if (Session["SuperUser"] == null && Session["OrgUser"] == null && Session["GroupUser"] == null && Session["ProjectUser"] == null)
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
        /// 展示Project
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
                    List<ModelForProject> list = new List<ModelForProject>();
                    if (Method == "FirstLoad")
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append(@"select
                                        p.*,
                                        o.Name OrgName,
                                        g.GroupName GroupName
                                        from 
                                        ProjectInfo p
                                        left join GroupInfo g on g.Id=p.GroupId
                                        left join OrgInfo o on o.Id=p.OrgId
                                        where p.IsDel!=1");
                        list = db.Database.SqlQuery<ModelForProject>(strSql.ToString()).ToList();
                    }
                    else if (Method == "SearchLoad")
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.AppendFormat(@"select
                                            p.*,
                                            o.Name OrgName,
                                            g.GroupName GroupName
                                            from 
                                            ProjectInfo p
                                            left join GroupInfo g on g.Id=p.GroupId
                                            left join OrgInfo o on o.Id=p.OrgId
                                            where p.IsDel!=1
                                            and p.ProjectName like '%{0}%'", Key);
                        list = db.Database.SqlQuery<ModelForProject>(strSql.ToString()).ToList();
                    }
                    int page = string.IsNullOrWhiteSpace(Request["page"]) ? 1 : Int32.Parse(Request["page"]);
                    int rows = string.IsNullOrWhiteSpace(Request["rows"]) ? 1 : Int32.Parse(Request["rows"]);
                    string order = string.IsNullOrWhiteSpace(Request["order"]) ? "DESC" : Request["order"].ToUpper();
                    string sort = string.IsNullOrWhiteSpace(Request["sort"]) ? "Id" : Request["sort"];
                    IQueryable<ProjectInfo> query = CommonTools.DataSorting<ProjectInfo>(list.AsQueryable(), sort, order).Skip((page - 1) * rows).Take(rows);
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
        /// ListGroup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ListGroup()
        {
            object objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"select
                                    o.Id ID,
                                    o.GroupName Name
                                    from GroupInfo o
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
        /// ListGroupBySearch
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ListGroupBySearch(int ProjectID)
        {
            object objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.AppendFormat(@"select
                                        o.Id ID,
                                        o.GroupName Name
                                        from GroupInfo o
                                        where (o.IsDel!=1 or o.IsDel is null)
                                        and o.OrgId='{0}'", ProjectID);
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
        /// Add Project
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(GlareSysEfDbAndModels.ProjectInfo subject)
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

                        subject.UpdateDt = DateTime.Now;
                        subject.CreateDt = DateTime.Now;
                        subject.IsDel = 0;
                        string strMsg = string.Empty;
                        bool b = ProjectBll.AddAProject(ref subject, out strMsg);
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
                        //db.ProjectInfo.Add(subject);
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
        /// Upadate Project
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Modify(GlareSysEfDbAndModels.ProjectInfo subject)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        ProjectInfo aSubject = db.ProjectInfo.Where(p => p.Id == subject.Id).FirstOrDefault();
                        aSubject.ProjectName = subject.ProjectName;
                        aSubject.ManagerName = subject.ManagerName;
                        aSubject.Address = subject.Address;
                        aSubject.ManagerTel = subject.ManagerTel;
                        aSubject.OrgId = subject.OrgId;
                        aSubject.GroupId = subject.GroupId;
                        aSubject.UpdateDt = DateTime.Now;
                        string strMsg = string.Empty;
                        bool b = ProjectBll.UpdateProejct(ref subject, out strMsg);
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
        /// DeleteProject
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string ProjectIds)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        string[] Id = ProjectIds.Split(',');
                        string strMsg = string.Empty;
                        for (int i = 0; i < Id.Length; i++)
                        {
                            ProjectBll.DeleteAProject(int.Parse(Id[i]), out strMsg);
                        }
                        objResult = new ResultHelper()
                        {
                            Status = true,
                            Ret = 0,
                            Obj = ProjectIds,
                            Msg = strMsg,
                            Desc = strMsg
                        };
                        //StringBuilder strSql = new StringBuilder();
                        //strSql.AppendFormat(@"UPDATE ProjectInfo SET IsDel = 1 WHERE Id IN ({0})", ProjectIds);
                        //if (db.Database.ExecuteSqlCommand(strSql.ToString()) > 0)
                        //{

                        //    objResult = new ResultHelper()
                        //    {
                        //        Status = true,
                        //        Ret = 0,
                        //        Obj = ProjectIds,
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
